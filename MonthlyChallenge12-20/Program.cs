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

        public static int PlayerX = 5;
        public static int PlayerY = 5;
        static void Main(string[] args)
        {
            Setup();

            while (true)
            {
                Input(Console.ReadKey());
                Logic();
                Render();
            }
        }

        public static void Setup()
        {
            Console.CursorVisible = false;

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
            GroundTile.Passable = true;
            GroundTile.SearchableType = TileTypeEnum.Ground;
            AllTypes.Add(GroundTile);

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (x == 0 || y == 0 || x == map.GetLength(0)-1 || y == map.GetLength(1)-1)
                    {
                        map[x, y] = AllTypes.Where(i => i.SearchableType == TileTypeEnum.Wall).ToArray()[0];
                    }
                    else
                    {
                        map[x, y] = AllTypes.Where(i => i.SearchableType == TileTypeEnum.Ground).ToArray()[0];
                    }
                    
                }
            }

            Render();
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

            Console.SetCursorPosition(PlayerX, PlayerY);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("O");
        }

        public static void Input(ConsoleKeyInfo Key)
        {
            switch (Key.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (PlayerX > 0 && map[PlayerX-1, PlayerY].Passable)
                    {
                        PlayerX--;
                    }
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (PlayerY > 0 && map[PlayerX, PlayerY - 1].Passable)
                    {
                        PlayerY--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (PlayerX < map.GetLength(0) && map[PlayerX + 1, PlayerY].Passable)
                    {
                        PlayerX++;
                    }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (PlayerY < map.GetLength(1) && map[PlayerX, PlayerY+1].Passable)
                    {
                        PlayerY++;
                    }
                    break;
                default:
                    break;
            }
        }

        public static void Logic()
        {

        }
    }
}
