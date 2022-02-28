using Adventure.Domain.DTO;
using Adventure.Domain.SeedWork.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Infrastructure.Hepler
{
    public static class AdventureTreeNodeHelper
    {
        public static AdventureDecisionTreeDTO ToQuestionTreeNode(this Adventure.Infrastructure.AdventureContext.Adventure entity, YesNoAnswer? type)
        {
            return new AdventureDecisionTreeDTO
            {
                AdventureId = entity.AdventureId,
                Question = entity.Question,
                Type = type,
            };
        }
    }
}
