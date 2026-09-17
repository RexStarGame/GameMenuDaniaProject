namespace GameMenu
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            PlayMineSweeper(args);
        }

        /// <summary>
        /// Mine Sweeper tile values.
        /// </summary>
        enum MsValues
        {
            HiddenSafe = 0,
            Safe = 1,
            FlagHiddenSafe = 2,
            HiddenBomb = 3,
            FlagHiddenBomb = 4
        };
        // MINESWEEPER BELLOW --------------------------------------------------------
        private static void PlayMineSweeper(string[] args)
        {
            const int bombCount = 40;
            string[] emojiList = {"⬛","⬜","🚩","💣"};
            const int gridSize = 15;
            Random random = new Random();
            MsValues[,] grid = GenerateGameBoard();
            GenerateBombs(grid);
            DrawGrid();
            RequestInput();

            void RequestInput()
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

            MsValues[,] GenerateGameBoard()
            {
                MsValues[,] newBoard = GenerateGrid();
                return newBoard;
            }
            /// <summary>
            /// Generate the gameboard.
            /// </summary>
            MsValues[,] GenerateGrid()
            {
                MsValues[,] newGrid = new MsValues[gridSize,gridSize];
                Console.WriteLine("Generated grid.");
                return newGrid;
            }

            void GenerateBombs(MsValues[,] inputGrid)
            {
                for (int b = 0; b < bombCount;)
                {
                    int[] tileCoord = PickRandomTile();
                    MsValues tileValue = GetTileValue(tileCoord);
                    if (tileValue == MsValues.HiddenSafe) ;
                    {
                        SetTileValue(tileCoord,MsValues.HiddenBomb);
                        b++;
                    }
                        
                }
                Console.WriteLine("Generated bombs.");
            }

            int[] PickRandomTile()
            {
                int x = random.Next(0, gridSize);
                int y = random.Next(0, gridSize);
                return new int[] {x, y}; //Coordinate

            }


            /// <summary>
            /// Do a check on a selected tile.
            /// </summary>
            void CheckTile(int[,] coord)
            {
                
            }
            /// <summary>
            /// Add, or remove, a flag from a hidden tile.
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="add"></param> if true; add, else remove.
            void FlagTile(int[] coord)
            {
                MsValues tileValue = GetTileValue(coord);
                if (tileValue == MsValues.Safe)
                {
                    return;
                }
                if (tileValue == MsValues.HiddenBomb) 
                {
                    SetTileValue(coord,MsValues.FlagHiddenBomb);
                }
                else if (tileValue == MsValues.FlagHiddenBomb) 
                {
                    SetTileValue(coord,MsValues.HiddenBomb);
                }
                else if (tileValue == MsValues.HiddenSafe)
                {
                    SetTileValue(coord, MsValues.FlagHiddenSafe);
                }
                else if (tileValue == MsValues.FlagHiddenSafe) 
                {
                    SetTileValue(coord,MsValues.HiddenSafe);
                }
            }

            MsValues GetTileValue(int[] coord)
            {
                return grid[coord[0],coord[1]];
            }
            
            void SetTileValue(int[] coord, MsValues newValue)
            {
                grid[coord[0],coord[1]] = newValue;
            }
            
            bool IsTileHidden(int[] coord)
            {
                return GetTileValue(coord) != MsValues.Safe;
            }

            bool IsTileFlagged(int[] coord)
            {
                return GetTileValue(coord) == MsValues.FlagHiddenBomb || GetTileValue(coord) == MsValues.FlagHiddenSafe;
            }

            void GameOver()
            {
                Console.WriteLine("YOU LOSE! :(");
            }

            void GameWin()
            {
                Console.WriteLine("YOU WIN!");
            }

            void DrawGrid()
            {
                int rows = grid.GetLength(0);
                int columns = grid.GetLength(1);
                // Column headers
                Console.Write("  ");
                for (int c = 0; c < columns; c++)
                {
                    Console.Write($"{c,3}");
                }

                Console.WriteLine();
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    // Row headers
                    Console.Write($"{x,3}");
                    for (int y = 0; y < grid.GetLength(1); y++)
                    {
                        string toWrite = "";
                        MsValues value = grid[x, y];
                        switch(value)
                        {
                            case MsValues.HiddenSafe:
                                toWrite = emojiList[0];
                                break;
                            case MsValues.Safe:
                                toWrite = emojiList[1];
                                break;
                            case MsValues.FlagHiddenSafe:
                                toWrite = emojiList[2];
                                break;
                            case MsValues.HiddenBomb:
                                toWrite = emojiList[0];
                                break;
                            case MsValues.FlagHiddenBomb:
                                toWrite = emojiList[2];
                                break;
                        }
                        Console.Write(toWrite+" ");
                    }

                    Console.WriteLine();
                }
            }

            string GetSafeTileSprite()
            {
                
            }
        }
    }
}
