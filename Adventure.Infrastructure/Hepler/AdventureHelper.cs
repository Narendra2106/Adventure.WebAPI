using Adventure.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Infrastructure.Hepler
{
    public static class AdventureHelper
    {
        public static AdventureDTO ToAdventure(this Adventure.Infrastructure.AdventureContext.Adventure entity)
        {
            return new AdventureDTO
            {
                AdventureId = entity.AdventureId,
                Question = entity.Question,
                IfNoNextQuestionId = entity.IfNoNextQuestionId,
                IfYesNextQuestionId = entity.IfYesNextQuestionId
            };
        }
    }
}
