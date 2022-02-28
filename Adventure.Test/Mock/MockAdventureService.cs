using Adventure.Domain.AggregatesModel;
using Adventure.Domain.DTO;
using Adventure.Domain.SeedWork.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Test.Mock
{
   public  class MockAdventureService : IAdventureService
    {
        public Task<AdventureDecisionTreeDTO> AdventureDecisionTree()
        {
            return Task.FromResult(new AdventureDecisionTreeDTO
            {
                AdventureId = 1,
                Question = "Do I want a doughnut?",
                Type = null,
                Children = new List<AdventureDecisionTreeDTO>
                    {
                        new AdventureDecisionTreeDTO
                        {
                            AdventureId = 2,
                            Question = "Do I deserve it?",
                            Type = YesNoAnswer.Yes,
                            Children = new List<AdventureDecisionTreeDTO>
                            {
                                new AdventureDecisionTreeDTO
                                {
                                    AdventureId = 4,
                                    Question = "Are you sure?",
                                    Type = YesNoAnswer.Yes,
                                    Children = new List<AdventureDecisionTreeDTO>
                                    {
                                       
                                        new AdventureDecisionTreeDTO
                                        {
                                            AdventureId = 6,
                                            Question = "Get it.",
                                            Type = YesNoAnswer.Yes
                                        },
                                           
                                        new AdventureDecisionTreeDTO
                                        {
                                            AdventureId = 7,
                                            Question = "Do jumping jacks first.",
                                            Type = YesNoAnswer.No
                                        }
                                    }

                                },
                                new AdventureDecisionTreeDTO
                                {
                                    AdventureId = 5,
                                    Question = "Is it a good doughnut?",
                                    Type = YesNoAnswer.No,
                                    Children = new List<AdventureDecisionTreeDTO>
                                    {
                                        new AdventureDecisionTreeDTO
                                        {
                                            AdventureId = 8,
                                            Question = "What are you waiting for? Grab it now.",
                                            Type = YesNoAnswer.Yes
                                        },
                                        new AdventureDecisionTreeDTO
                                        {
                                            AdventureId = 9,
                                            Question = "Wait `till you find a sinful, unforgettable doughnut.",
                                            Type = YesNoAnswer.No
                                        }
                                    }
                                }
                            }
                        },
                        new AdventureDecisionTreeDTO
                        {
                            AdventureId = 3,
                            Question = "Maybe you want an apple?",
                            Type = YesNoAnswer.No
                        }
                    }
            });
        }

        public Task<AdventureDTO> AdventureById(int id) 
        {
            return Task.FromResult(new AdventureDTO
            {
                AdventureId = 1,
                Question = "Do I want a doughnut?",
                IfYesNextQuestionId = 2,
                IfNoNextQuestionId = 3
            });
        }
    }
}
