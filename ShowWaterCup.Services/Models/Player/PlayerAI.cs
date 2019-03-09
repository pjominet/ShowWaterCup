using System.Collections.Generic;
using ShowWaterCup.Services.Models.Enums;
using ShowWaterCup.Services.Models.Tournament;

namespace ShowWaterCup.Services.Models.Player
{
    public class PlayerAI
    {
        private PlayerInstance _player;
        private List<PlayerAIStep> _aiSteps;

        public int AiId { get; set; }
        public int PlayerId { get; set; }

        public PlayerAI(PlayerInstance player)
        {
            _player = player;
            _aiSteps = new List<PlayerAIStep>();
        }

        public RoundAction Play()
        {
            var round = new RoundAction
            {
                PlayerId = _player.PlayerId,
                ActionType = ActionType.Move,
                Direction = Direction.Down,
                Target = new PlayerPosition(_player.Position.X, _player.Position.Y -= 1)
            };

            if (round.ActionType == ActionType.Move)
                Move(round.Target, round.Direction);
            else Attack(round.Target);

            return round;
        }

        public void Move(PlayerPosition newPosition, Direction direction)
        {
            if (newPosition.IsAvailable(direction) && _player.ActionPoints > 0)
            {
                _player.Position = newPosition;
                _player.ActionPoints -= 1;
            }
        }

        public void Attack(PlayerPosition targetPosition)
        {
            var target = GetTargetPlayer(targetPosition);
            if (target != null && _player.ActionPoints > 0)
            {
                target.Hitpoints -= 1;
                _player.ActionPoints -= 1;
            }
        }

        public PlayerInstance GetTargetPlayer(PlayerPosition position)
        {
            // if position has enemy
            return null;
        }
    }
}