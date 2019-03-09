using System.Collections.Generic;
using ShowWaterCup.Services.Models.Enums;

namespace ShowWaterCup.Services.Models.Player
{
    public class PlayerAIStep
    {
        public ActionType ActionType { get; set; }
        public PlayerAI PlayerAI { get; set; }
        public ICollection<PlayerAIStep> AISteps { get; set; }
        public PlayerAIStep ParentAIStep { get; set; }

        public int AiId { get; set; }
        public int? ParentStepId { get; set; }
        public int ActionTypeId { get; set; }
        public int PlayerAIStepId { get; set; }

    }
}