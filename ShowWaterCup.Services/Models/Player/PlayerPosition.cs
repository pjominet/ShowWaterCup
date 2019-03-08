using ShowWaterCup.Services.Models.Enums;

namespace ShowWaterCup.Services.Models.Player
{
    public class PlayerPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PlayerPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsAvailable(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return Y > 0;
                case Direction.Down:
                    return Y < 9;
                case Direction.Left:
                    return X > 0;
                case Direction.Right:
                    return X < 9;
                default:
                    return false;
            }
        }
    }
}