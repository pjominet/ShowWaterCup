using System;
using System.Collections.Generic;
using System.Numerics;
using ShowWaterCup.Services.Models.Enums;
using ShowWaterCup.Services.Models.Tournament;

namespace ShowWaterCup.Services.Models.Player
{
    public class PlayerAI
    {
        private PlayerInstance _player;
        private List<PlayerAIStep> _aiSteps;

        public PlayerAI(PlayerInstance player)
        {
            _player = player;
            _aiSteps = new List<PlayerAIStep>();
        }

        public RoundAction Play()
        {
            var action = new RoundAction
            {
                PlayerId = _player.PlayerId,
                ActionType = ActionType.Move,
                Direction = Direction.Down,
                Target = new MapPosition(_player.Position.X, _player.Position.Y -= 1)
            };

            if (action.ActionType == ActionType.Move)
                Move(action.Target, action.Direction);
            else Attack(action.Target);

            return action;
        }

        public void Move(MapPosition newPosition, Direction direction)
        {
            if (newPosition.IsOutOfBounds(direction) 
                && !newPosition.IsOccupied()
                && _player.ActionPoints > 0)
            {
                _player.Position = newPosition;
                _player.ActionPoints -= 1;
            }
        }

        public void Attack(MapPosition targetPosition)
        {
            if (targetPosition.IsOccupied() && _player.ActionPoints > 0)
            {
                var target = targetPosition.Occupant;
                target.Hitpoints -= 1;
                _player.ActionPoints -= 1;
            }
        }

        public PlayerInstance GetClosetEnemy()
        {
            var allEnemyPosition = new List<MapPosition>();
            foreach (var field in _player.ViewRadius)
            {
                if(field.IsOccupied())
                    allEnemyPosition.Add(field);
            }
            
            allEnemyPosition.Sort((origin, position) =>
                (int) (Vector2.Distance(position.Transform(), origin.Transform()) * 100));
            
            return allEnemyPosition[0].Occupant;
        }
    }
}