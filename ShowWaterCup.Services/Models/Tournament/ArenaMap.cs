using System.Collections.Generic;
using ShowWaterCup.Services.Models.Player;
using System.Linq;
using ShowWaterCup.Services.Models.Enums;

namespace ShowWaterCup.Services.Models.Tournament
{
    public class ArenaMap
    {
        public const int ARENA_SIZE = 20;
        public List<MapPosition> Fields { get; set; }

        public ArenaMap()
        {
            Fields = new List<MapPosition>();
            
            for (var i = 1; i <= ARENA_SIZE; i++)
            {
                for (var j = 1; j <= ARENA_SIZE; j++)
                {
                    Fields.Add(new MapPosition(i, j));
                }
            }
        }

        public MapPosition GetField(int x, int y)
        {
            return Fields.First(f => f.X == x && f.Y == y);
        }

        public void Flood()
        {
            for (var i = 1; i <= 10; i++)
            {
                var field = Fields.First(f => f.X == i && f.Y == i);
                if (field.FieldType == Enums.FieldType.Dirt)
                {
                    FloodNextRing(i, FieldType.Water);
                    if (i > 1)
                    {
                        FloodNextRing(i - 1, FieldType.DeepWater);
                    }
                }
            }
        }

        private void FloodNextRing(int position, FieldType fieldType)
        {
            FloodRow(position, fieldType);
            FloodRow(ARENA_SIZE - position, fieldType);
            FloodCol(position, fieldType);
            FloodCol(ARENA_SIZE - position, fieldType);
        }

        private void FloodRow(int row, FieldType type)
        {
            for (int i = 0; i < ARENA_SIZE; i++)
            {
                var field = Fields.First(f => f.X == row);
                field.FieldType = type;
            }
        }

        private void FloodCol(int col, FieldType type)
        {
            for (int i = 0; i < ARENA_SIZE; i++)
            {
                var field = Fields.First(f => f.Y == col);
                field.FieldType = type;
            }
        }
    }
}