using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ShowWaterCup.Services.Models.Enums;
using ShowWaterCup.Services.Models.Tournament;

namespace ShowWaterCup.Services.Models.Player
{
    public class PlayerAI
    {
        private readonly PlayerInstance _player;
        private ArenaMap Map { get; set; }

        public int AiId { get; set; }
        public int PlayerId { get; set; }

        public PlayerAI(PlayerInstance player)
        {
            _player = player;
        }

        public RoundAction Play()
        {
            if (IsDead()) 
                return null;
            
            var action = getAction();
            switch (action.ActionType)
            {
                case ActionType.Move:
                    Move(action.Direction);
                    break;
                case ActionType.CloseIn:
                    CloseIn();
                    break;
                case ActionType.Flee:
                    Flee();
                    break;
                case ActionType.Attack:
                    Attack(action.TargetPosition);
                    break;
                case ActionType.MoveCenter:
                    MoveToCenter();
                    break;
                default:
                    break;
            }

            return action;
        }

        #region ai_status

        public bool WetFeet()
        {
            return _player.Position.FieldType == FieldType.Water;
        }

        public bool IsDead()
        {
            return _player.Hitpoints <= 0;
        }

        #endregion

        #region ai_moves

        public void Move(Direction direction)
        {
            var newPosition = _player.Position;
            switch (direction)
            {
                case Direction.Up:
                    newPosition.Y -= 1;
                    break;
                case Direction.Down:
                    newPosition.Y += 1;
                    break;
                case Direction.Left:
                    newPosition.X -= 1;
                    break;
                case Direction.Right:
                    newPosition.X += 1;
                    break;
                case Direction.None:
                    goto default;
                default:
                    break;
            }
            
            if (newPosition.MovementOutOfBounds(direction) && !MapPosition.IsOccupied(newPosition) && _player.ActionPoints > 0)
            {
                _player.Position = newPosition;
                _player.ActionPoints -= 1;
            }
        }

        public void CloseIn()
        {
            var direction = GetAttackDirection();
            Move(direction);
        }

        public void Flee()
        {
            var direction = GetEscapeDirection();
            Move(direction);
        }
        
        public void Attack(MapPosition targetPosition)
        {
            if (MapPosition.IsOccupied(targetPosition) && _player.ActionPoints > 0)
            {
                var target = targetPosition.Occupant;
                target.Hitpoints -= 1;
                _player.ActionPoints -= 1;
            }
        }

        public void MoveToCenter()
        {
            var direction = GetCenterDirection();
            Move(direction);
        }
        
        #endregion

        #region helpers

        private PlayerInstance GetClosestEnemy()
        {
            var allEnemyPosition = new List<MapPosition>();
            // traverse ViewRadius
            for (var i = 1; i <= _player.ViewRadius; i++)
            {
                for (var j = 1; j <= _player.ViewRadius; j++)
                {
                    var x = _player.Position.X - _player.ViewRadius + i;
                    var y = _player.Position.Y - _player.ViewRadius + j;
                    var inspectedPosition = new MapPosition(x, y);
                    if (!MapPosition.IsOutOfBounds(inspectedPosition))
                    {
                        var field = Map.GetField(x, y);
                        if (MapPosition.IsOccupied(field))
                            allEnemyPosition.Add(field);
                    }
                }
            }

            if (allEnemyPosition.Count > 0)
            {
                allEnemyPosition.Sort((origin, position) =>
                    (int) (Vector2.Distance(position.DistanceAsVector(), origin.DistanceAsVector()) * 100));
                return allEnemyPosition[0].Occupant;
            }

            return null;
        }
        
        private double GetAngle(MapPosition pos1, MapPosition pos2)
        {
            float deltaX = pos2.X - pos1.X;
            float deltaY = pos2.Y - pos1.Y;
            return Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;
        }

        private Direction AdvanceDirection(double angle)
        {
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

        private Direction RetreatDirection(double angle)
        {
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
        
        private Direction GetAttackDirection()
        {
            var enemy = GetClosestEnemy();
            if (enemy == null) 
                return Direction.None;
            
            var angle = GetAngle(_player.Position, enemy.Position);
            return AdvanceDirection(angle);
        }

        private Direction GetEscapeDirection()
        {
            var enemy = GetClosestEnemy();
            if (enemy == null)
                return Direction.None;
                    
            var angle = GetAngle(_player.Position, enemy.Position);
            return RetreatDirection(angle);
        }

        private IEnumerable<MapPosition> MapCenter()
        {
            var centerCoords = ArenaMap.ARENA_SIZE / 2;

            var mapCenter = new List<MapPosition>
            {
                new MapPosition(centerCoords, centerCoords),
                new MapPosition(centerCoords + 1, centerCoords),
                new MapPosition(centerCoords, centerCoords + 1),
                new MapPosition(centerCoords + 1, centerCoords + 1)
            };

            return mapCenter;
        }

        private Direction GetCenterDirection()
        {
            var centerFields = MapCenter();
            var freeField = centerFields.First(t => MapPosition.IsOccupied(t) == false);
            var angle = GetAngle(_player.Position, freeField);

            return AdvanceDirection(angle);
        }
        
        // Get action from XML Action Parser
        private RoundAction getAction() 
        {
            // mock action
            return new RoundAction
            {
                PlayerId = _player.PlayerId,
                ActionType = GetRandomActiontType(),
                Direction = GetRandomDirection(),
            };
        }
        
        #endregion

        #region mocking

        private Direction GetRandomDirection()
        {
            var rnd = new Random();
            switch (rnd.Next(1, 4))
            {
                case 1:
                    return Direction.Down;
                case 2:
                    return Direction.Left;
                case 3:
                    return Direction.Right;
                case 4:
                    return Direction.Up;
                default:
                    return Direction.None;
            }
        }

        private ActionType GetRandomActiontType()
        {
            var rnd = new Random();
            switch (rnd.Next(1, 3))
            {
                case 1:
                    return ActionType.Move;
                case 2:
                    return ActionType.MoveCenter;
                case 3:
                    return ActionType.Flee;
                default:
                    return ActionType.Move;
            }
        }

        #endregion
    }
}