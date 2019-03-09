using ShowWaterCup.Services.Models.Enums;
using ShowWaterCup.Services.Models.Player;

namespace ShowWaterCup.Services.Models.Tournament
{
    public class RoundAction
    {
        public int PlayerId { get; set; }
        public ActionType ActionType { get; set; }
        public MapPosition TargetPosition { get; set; }
        public Direction Direction { get; set; }
    }
}