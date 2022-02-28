using Adventure.API.Controllers;
using Adventure.Domain.DTO;
using Adventure.Test.Mock;
using Adventure.Test.TestData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Adventure.Test
{
    public class AdventureTest
    {
        private readonly MockAdventureService _mockAdventureService;
        private readonly AdventureController _adventureController;

        public AdventureTest()
        {
            _mockAdventureService = new MockAdventureService();
            var mockLogger = NullLogger<AdventureController>.Instance;
            _adventureController = new AdventureController(mockLogger, _mockAdventureService);
        }

        [Fact]
        public async Task ShouldReturnDecisionTreeAsync()
        {
            var expectedResult = AdventureDecisionTreeData.DecisionTree();
            var actionResult = await _adventureController.GetAdventureDecisionTree();
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(actionResult);

            var result = Assert.IsType<AdventureDecisionTreeDTO>(okObjectResult.Value);

            Assert.NotNull(result);
            Assert.Equal<AdventureDecisionTreeDTO>(expectedResult, result);
        }

        [Fact]
        public async Task ShouldReturnAdventureAsync()
        {
            int expected = 1;
            var actionResult = await _adventureController.GetAdventure(expected);
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(actionResult);

            var result = Assert.IsType<AdventureDTO>(okObjectResult.Value);

            Assert.NotNull(result);
            Assert.Equal(expected, result.AdventureId);

        }
    }
}
