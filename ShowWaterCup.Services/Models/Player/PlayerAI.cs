using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
                TargetPosition = new MapPosition(_player.Position.X, _player.Position.Y -= 1)
            };

            switch (action.ActionType)
            {
                case ActionType.Move:
                    Move(action.TargetPosition, action.Direction);
                    break;
                case ActionType.CloseIn:
                    CloseIn(action.TargetPosition);
                    break;
                case ActionType.Flee:
                    Flee(action.TargetPosition);
                    break;
                case ActionType.Attack:
                    Attack(action.TargetPosition);
                    break;
                default:
                    break;
            }

            return action;
        }

        #region ai_moves

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

        public void CloseIn(MapPosition newPosition)
        {
            var direction = GetAttackDirection();
            Move(newPosition, direction);
        }

        public void Flee(MapPosition newPosition)
        {
            var direction = GetFlightDirection();
            Move(newPosition, direction);
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

        #endregion

        #region helpers

        private PlayerInstance GetClosetEnemy()
        {
            var allEnemyPosition = new List<MapPosition>();
            foreach (var field in _player.ViewRadius)
            {
                if (field.IsOccupied())
                    allEnemyPosition.Add(field);
            }

            allEnemyPosition.Sort((origin, position) =>
                (int) (Vector2.Distance(position.Transform(), origin.Transform()) * 100));

            return allEnemyPosition[0].Occupant;
        }
        
        private double GetAngle(PlayerInstance player, PlayerInstance enemy)
        {
            float deltaX = enemy.Position.X - _player.Position.X;
            float deltaY = enemy.Position.Y - _player.Position.Y;
            return Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;
        }
        
        private Direction GetAttackDirection()
        {
            var enemy = GetClosetEnemy();
            var angle = GetAngle(_player, enemy);

            var direction = Direction.Up;
            if (angle >= 45 && angle < 135)
            {
                direction = Direction.Right;
            }

            if (angle >= 135 && angle < 225)
            {
                direction = Direction.Down;
            }

            if (angle >= 225 && angle < 315)
            {
                direction = Direction.Left;
            }

            return direction;
        }

        private Direction GetFlightDirection()
        {
            var enemy = GetClosetEnemy();
            var angle = GetAngle(_player, enemy);
                
            var direction = Direction.Down;
            if (angle >= 45 && angle < 135)
            {
                direction = Direction.Left;
            }

            if (angle >= 135 && angle < 225)
            {
                direction = Direction.Up;
            }

            if (angle >= 225 && angle < 315)
            {
                direction = Direction.Right;
            }

            return direction;
        }

        #endregion
    }
}