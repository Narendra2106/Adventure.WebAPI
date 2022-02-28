using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.API.Filter
{
    public class ExceptionActionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionActionFilter> logger;

        public ExceptionActionFilter(ILogger<ExceptionActionFilter> logger)
        {
            this.logger = logger;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var actionDescriptor = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            Type controllerType = actionDescriptor.ControllerTypeInfo;

            var controllerBase = typeof(ControllerBase);
            var controller = typeof(Controller);

            if (controllerType.IsSubclassOf(controllerBase) && !controllerType.IsSubclassOf(controller))
            {
                ProblemDetails pd = new ProblemDetails();
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.HttpContext.Response.ContentType = "application/problem+json";
                pd.Status = StatusCodes.Status500InternalServerError;
                pd.Title = "Internal Server Error";
                pd.Detail = context.Exception.Message;
                context.Result = new JsonResult(pd);
            }

            context.ExceptionHandled = true;
            logger.LogError(new EventId(0), context.Exception, context.Exception.Message);
            await base.OnExceptionAsync(context);
        }
    }
}

