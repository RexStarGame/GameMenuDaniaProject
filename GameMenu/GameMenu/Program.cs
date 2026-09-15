namespace GameMenu
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MineSweeper.Play(args);
        }

        private static class MineSweeper
        {
            private static int _bombCount = 40;

            public enum Values
            {
                HiddenSafe = 0,
                Safe = 1,
                FlagHiddenSafe = 2,
                HiddenBomb = 3,
                FlagHiddenBomb = 4
            };

            public static string[] emojiList = {"⬛","⬜","🚩","💣"};
            
            /// <summary>
            /// The size of the 1:1 grid.
            /// </summary>
            private static int _gridSize = 15;
            /// <summary>
            /// The grid contents.
            /// </summary>
            private static Values[,] _grid = { };
            /// <summary>
            /// Start the game. Minesweeper.
            /// </summary>
            public static void Play(string[] args)
            {
                _grid = GenerateGameBoard();
                GenerateBombs(_grid);
                DrawGrid();
                RequestInput();
            }

            public static void RequestInput()
            {
                
                Console.WriteLine("Choose a tile..");
                
                Console.Write("X = ");
                string inputX = Console.ReadLine();
                int xCoord = int.Parse(inputX);
                
                Console.Write("Y = ");
                string inputY = Console.ReadLine();
                int yCoord = int.Parse(inputY);
                
                int[] coord = [xCoord, yCoord];
                Console.WriteLine("What would you like to do at ("+xCoord+"."+yCoord+")?");
                Console.WriteLine(" ");
                Console.WriteLine("   1. Reveal the tile.");
                Console.WriteLine("   2. Flag/unflag the tile.");
                Console.WriteLine("   3. Pick a different tile.");
                string action = Console.ReadLine();
                
            }

            private static Values[,] GenerateGameBoard()
            {
                Values[,] newBoard = GenerateGrid();
                return newBoard;
            }
            /// <summary>
            /// Generate the gameboard.
            /// </summary>
            private static Values[,] GenerateGrid()
            {
                Values[,] newGrid = new Values[_gridSize,_gridSize];
                Console.WriteLine("Generated grid.");
                return newGrid;
            }

            private static void GenerateBombs(Values[,] inputGrid)
            {
                for (int b = 0; b < _bombCount;)
                {
                    int[] tileCoord = PickRandomTile();
                    Values tileValue = GetTileValue(tileCoord);
                    if (tileValue == Values.HiddenSafe) ;
                    {
                        SetTileValue(tileCoord,Values.HiddenBomb);
                        b++;
                    }
                        
                }
                Console.WriteLine("Generated bombs.");
            }

            private static int[] PickRandomTile()
            {
                Random r = new Random();
                int x = r.Next(0, _gridSize);
                int y = r.Next(0, _gridSize);
                return new int[] {x, y}; //Coordinate

            }


            /// <summary>
            /// Do a check on a selected tile.
            /// </summary>
            public static void CheckTile(int[,] coord)
            {
                
            }
            /// <summary>
            /// Add, or remove, a flag from a hidden tile.
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="add"></param> if true; add, else remove.
            public static void FlagTile(int[] coord)
            {
                Values tileValue = GetTileValue(coord);
                if (tileValue == Values.Safe)
                {
                    return;
                }
                if (tileValue == Values.HiddenBomb) 
                {
                    SetTileValue(coord,Values.FlagHiddenBomb);
                }
                else if (tileValue == Values.FlagHiddenBomb) 
                {
                    SetTileValue(coord,Values.HiddenBomb);
                }
                else if (tileValue == Values.HiddenSafe) 
                {
                    SetTileValue(coord,Values.FlagHiddenSafe);
                }
                else if (tileValue == Values.FlagHiddenSafe) 
                {
                    SetTileValue(coord,Values.HiddenSafe);
                }
            }

            private static Values GetTileValue(int[] coord)
            {
                return _grid[coord[0],coord[1]];
            }
            
            private static void SetTileValue(int[] coord, Values newValue)
            {
                _grid[coord[0],coord[1]] = newValue;
            }
            
            public static bool IsTileHidden(Values[,] coord)
            {
                return true;
            }

            public static bool IsTileFlagged(int[,] coord)
            {
                return true;
            }

            public static void GameOver()
            {
                Console.WriteLine("YOU LOSE! :(");
            }

            public static void GameWin()
            {
                Console.WriteLine("YOU WIN!");
            }

            private static void DrawGrid()
            {
                int rows = _grid.GetLength(0);
                int columns = _grid.GetLength(1);
                // Column headers
                Console.Write("  ");
                for (int c = 0; c < columns; c++)
                {
                    Console.Write($"{c,3}");
                }

                Console.WriteLine();
                for (int x = 0; x < _grid.GetLength(0); x++)
                {
                    // Row headers
                    Console.Write($"{x,3}");
                    for (int y = 0; y < _grid.GetLength(1); y++)
                    {
                        string toWrite = "";
                        Values value = _grid[x, y];
                        switch(value)
                        {
                            case Values.HiddenSafe:
                                toWrite = emojiList[0];
                                break;
                            case Values.Safe:
                                toWrite = emojiList[1];
                                break;
                            case Values.FlagHiddenSafe:
                                toWrite = emojiList[2];
                                break;
                            case Values.HiddenBomb:
                                toWrite = emojiList[0];
                                break;
                            case Values.FlagHiddenBomb:
                                toWrite = emojiList[2];
                                break;
                        }
                        Console.Write(toWrite+" ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
