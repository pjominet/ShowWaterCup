using ShowWaterCup.Services.Models.Tournament;

namespace ShowWaterCup.Services.Models.Player
{
    public class PlayerAi
    {
        private PlayerInstance _player;

        public PlayerAi(PlayerInstance player)
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