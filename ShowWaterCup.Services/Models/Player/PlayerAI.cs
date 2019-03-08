using ShowWaterCup.Services.Models.Tournament;

namespace ShowWaterCup.Services.Models.Player
{
    public class PlayerAI
    {
        private PlayerInstance _player;

        public PlayerAI(PlayerInstance player)
        {
            _player = player;
        }

        public RoundAction Play()
        {
            var round = new RoundAction();
            return round;
        }
    }
}