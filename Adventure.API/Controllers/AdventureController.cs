using Adventure.Domain.AggregatesModel;
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
    [Route("api/adventure")]
    [ApiController]
    public class AdventureController : ControllerBase
    {

        private readonly ILogger<AdventureController> _logger;
        private readonly IAdventureService _adventureService;
        public AdventureController(ILogger<AdventureController> logger, IAdventureService adventureService)
        {
            _logger = logger;
            _adventureService = adventureService;
        }


        /// <summary>
        /// Get All Adventure 
        /// </summary>
        /// <returns>JWT token string</returns>
        [HttpGet("decisionTree")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdventureDecisionTreeDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult> GetAdventureDecisionTree()
        {
            _logger.LogDebug("API GetAdventureDecisionTree was called");

            var result = await _adventureService.AdventureDecisionTree();
  
           return Ok(result);

        }

        /// <summary>
        /// Get All Adventure by Id
        /// </summary>
        /// <param name="adventureId"></param>
        /// <returns>JWT token string</returns>
        [HttpGet("{adventureId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdventureDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult> GetAdventure(int adventureId)
        {
            _logger.LogDebug("API GetAdventure was called");

            var adventure = await _adventureService.AdventureById(adventureId);

            if (adventure == null)
                return NotFound();

            return Ok(adventure);
        }

        
    }
}
