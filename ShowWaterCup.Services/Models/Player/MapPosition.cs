using System.Numerics;
using ShowWaterCup.Services.Models.Enums;

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

        public bool IsOutOfBounds(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return Y < 1;
                case Direction.Down:
                    return Y > 10;
                case Direction.Left:
                    return X < 1;
                case Direction.Right:
                    return X > 10;
                default:
                    return false;
            }
        }

        public bool IsOccupied()
        {
            return Occupant.Position.Equals(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is MapPosition otherPosition)
                return X == otherPosition.X && Y == otherPosition.Y;
            else return false;
        }

        public Vector2 Transform()
        {
            return new Vector2(X, Y);
        }
    }
}