using System.Numerics;
using ShowWaterCup.Services.Models.Enums;
using ShowWaterCup.Services.Models.Tournament;

namespace ShowWaterCup.Services.Models.Player
{
    public class MapPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public FieldType FieldType { get; set; }

        public PlayerInstance Occupant { get; set; }

        public MapPosition(int x, int y)
        {
            X = x;
            Y = y;
            FieldType = FieldType.Dirt;
        }

        public bool MovementOutOfBounds(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return Y < 1;
                case Direction.Down:
                    return Y > ArenaMap.ARENA_SIZE;
                case Direction.Left:
                    return X < 1;
                case Direction.Right:
                    return X > ArenaMap.ARENA_SIZE;
                case Direction.None:
                    goto default;
                default:
                    return false;
            }
        }

        public static bool IsOutOfBounds(MapPosition position)
        {
            return position.Y < 0 || position.Y > ArenaMap.ARENA_SIZE ||
                   position.X < 0 || position.X > ArenaMap.ARENA_SIZE;
        }

        public static bool IsOccupied(MapPosition position)
        {
            return position.Occupant != null;
        }


        public Vector2 DistanceAsVector()
        {
            return new Vector2(X, Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is MapPosition otherPosition)
                return X == otherPosition.X && Y == otherPosition.Y;
            else return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}