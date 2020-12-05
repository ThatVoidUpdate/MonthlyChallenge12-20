using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyChallenge12_20
{
    class LevelGenerator
    {
        public static TileTypeEnum[,] GenerateLevel()
        {
            TileTypeEnum[,] map = new TileTypeEnum[20, 10];

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (x == 0 || y == 0 || x == map.GetLength(0) - 1 || y == map.GetLength(1) - 1)
                    {
                        map[x, y] = TileTypeEnum.Wall;
                    }
                    else
                    {
                        map[x, y] = TileTypeEnum.Ground;
                    }

                }
            }

            return map;
        }
    }
}
