using ShowWaterCup.Services.Models.Enums;

namespace ShowWaterCup.Services.Models
{
    public class RoundAction
    {
        public int PlayerId { get; set; }
        public ActionType ActionType { get; set; }
        public string Target { get; set; }
    }
}