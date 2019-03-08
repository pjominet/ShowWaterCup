using ShowWaterCup.Services.Models.Enums;

namespace ShowWaterCup.Services.Models.Player
{
    public class PlayerPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool CanMove(Directions directions)
        {
            switch (directions)
            {
                case Directions.Up:
                    return Y > 0;
                case Directions.Down:
                    return Y < 9;
                case Directions.Left:
                    return X > 0;
                case Directions.Right:
                    return X < 9;
                default:
                    return false;
            }
        }
    }
}