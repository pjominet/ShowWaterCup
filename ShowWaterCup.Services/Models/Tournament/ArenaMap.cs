using System.Collections.Generic;
using ShowWaterCup.Services.Models.Player;
using System.Linq;
using ShowWaterCup.Services.Models.Enums;

namespace ShowWaterCup.Services.Models.Tournament
{
    public class ArenaMap
    {
        public const int ARENA_SIZE = 20;
        //public SortedDictionary<int, int> Arena { get; set; }
        public List<MapPosition> Fields { get; set; }

        public ArenaMap()
        {
            //Arena = new SortedDictionary<int, int>();
            Fields = new List<MapPosition>();
            
            for (var i = 1; i <= ARENA_SIZE; i++)
            {
                for (var j = 1; j <= ARENA_SIZE; j++)
                {
                    //Arena.Add(i, j);
                    Fields.Add(new MapPosition(i, j));
                }
            }
        }

        public void Flood()
        {
            for (int i = 1; i <= 10; i++)
            {
                var field = Fields.First(f => f.X == i && f.Y == i);
                if (field.FieldType == Enums.FieldType.Dirt)
                {
                    FloodPosition(i, FieldType.Water);
                    if (i > 1)
                    {
                        FloodPosition(i - 1, FieldType.DeepWater);
                    }
                }
            }
        }

        private void FloodPosition(int position, FieldType fieldType)
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