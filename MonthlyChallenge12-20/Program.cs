using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyChallenge12_20
{
    class Program
    {
        public static List<TileType> AllTypes = new List<TileType>();
        public static TileType[,] map = new TileType[10, 10]; 
        static void Main(string[] args)
        {
            Setup();
        }

        public static void Setup()
        {
            TileType WallTile = new TileType();
            WallTile.BackgroundColour = ConsoleColor.Gray;
            WallTile.ForegroundColour = ConsoleColor.DarkGray;
            WallTile.DisplaySymbol = '▒';
            WallTile.Passable = false;
            WallTile.SearchableType = TileTypeEnum.Wall;
            AllTypes.Add(WallTile);

            TileType GroundTile = new TileType();
            GroundTile.BackgroundColour = ConsoleColor.DarkYellow;
            GroundTile.ForegroundColour = ConsoleColor.DarkGreen;
            GroundTile.DisplaySymbol = '.';
            GroundTile.Passable = false;
            GroundTile.SearchableType = TileTypeEnum.Ground;
            AllTypes.Add(GroundTile);

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = AllTypes.Where(i => i.SearchableType == TileTypeEnum.Ground).ToArray()[0];
                }
            }

            Render();
            Console.Read();
        }


        public static void Render()
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = map[x, y].ForegroundColour;
                    Console.BackgroundColor = map[x, y].BackgroundColour;
                    Console.Write(map[x, y].DisplaySymbol);
                }
            }
        }

        public static void Logic()
        {

        }
    }
}
