using Adventure.Domain.AggregatesModel.AdventureType;
using Adventure.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.API.Controllers
{
    [Route("api/adventuretype")]
    [ApiController]
    public class AdventureTypeController : ControllerBase
    {
        private readonly ILogger<AdventureTypeController> _logger;
        private readonly IAdventureTypeService _adventureTypeService;
        public AdventureTypeController(ILogger<AdventureTypeController> logger, IAdventureTypeService adventureTypeService)
        {
            _logger = logger;
            _adventureTypeService = adventureTypeService;
        }


        /// <summary>
        /// Create a Adventure Type
        /// </summary>
        /// <remarks>Create a Adventure Type</remarks>
        /// <param name="adventureTypeDTO">Adventure Type DTO</param>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 400 Bad Request </returns>
        /// <returns>Returns 401 Unauthorized error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        /// 
        [HttpPost("createAdventureType")]

        [ProducesResponseType(StatusCodes.Status200OK, Type =  typeof(AdventureTypeDTO))]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult> CreateAdventureType(AdventureTypeDTO adventureTypeDTO)
        {
            _logger.LogDebug("CreateAdventureType was called");

            var result = await _adventureTypeService.CreateAdventureType(adventureTypeDTO);

            return Ok(result);
        }

    }
}
