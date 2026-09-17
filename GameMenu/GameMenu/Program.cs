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
            FlagHiddenBomb = 4,
            Bomb = 5
        };
        // MINESWEEPER BELLOW --------------------------------------------------------
        private static void PlayMineSweeper(string[] args)
        {
            const int bombCount = 40;
            string[] emojiList = {"⬛","⬜","🚩","💣"};
            string[] numbList = { "0 ","1 ", "2 ", "3 ", "4 ", "5 ", "6 ", "7 ", "8 " };
            const int gridSize = 15;
            Random random = new Random();
            MsValues[,] grid = GenerateGameBoard();
            GenerateBombs(grid);
            
            RequestInput();

            void RequestInput()
            {
                DrawGrid();
                Console.WriteLine("Choose a tile..");
                
                Console.Write("X = ");
                string inputX = Console.ReadLine();
                int coordColumn = int.Parse(inputX);
                
                Console.Write("Y = ");
                string inputY = Console.ReadLine();
                int coordRow = int.Parse(inputY);
                
                
                int[] coord = [coordRow, coordColumn];
                Console.WriteLine("What would you like to do at ("+coordColumn+"."+coordRow+")?");
                Console.WriteLine(" ");
                Console.WriteLine("   1. Reveal the tile.");
                Console.WriteLine("   2. Flag/unflag the tile.");
                Console.WriteLine("   3. Pick a different tile.");
                string action = Console.ReadLine();
                switch (action)
                {
                    case "1": // reveal tile
                        MsValues tileValue = RevealTile(coord);
                        if (tileValue != MsValues.HiddenBomb)
                        {
                            RequestInput();
                        }
                        break;
                    case "2": // Flag tile
                        FlagTile(coord);
                        RequestInput();
                        break;
                    case "3": // Pick different tile
                        RequestInput();
                        break;
                    default: // invalid input
                        Console.WriteLine(("INVALID INPUT"));
                        RequestInput();
                        break;
                }
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

            MsValues RevealTile(int[] coord)
            {
                MsValues value = GetTileValue(coord);
                switch (value)
                {
                case MsValues.HiddenBomb:
                    GameOver(coord);
                    break;
                case MsValues.HiddenSafe:
                    SetTileValue(coord,MsValues.Safe);
                    break;
                }

                return value;
            }
            
            
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

            void GameOver(int[] coord)
            {
                SetTileValue(coord,MsValues.Bomb);
                DrawGrid();
                Console.WriteLine("                             ____\n                     __,-~~/~    `---.\n                   _/_,---(      ,    )\n               __ /        <    /   )  \\___\n- ------===;;;'====------------------===;;;===----- -  -\n                  \\/  ~\"~\"~\"~\"~\"~\\~\"~)~\"/\n                  (_ (   \\  (     >    \\)\n                   \\_( _ <         >_>'\n                      ~ `-i' ::>|--\"\n                          I;|.|.|\n                         <|i::|i|`.\n                        (` ^'\"`-' \")\n");
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
                        int[] coord = [x, y];
                        switch(value)
                        {
                            case MsValues.HiddenSafe:
                                toWrite = emojiList[0];
                                break;
                            case MsValues.Safe:
                                toWrite = GetSafeTileSprite(coord);
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
                            case MsValues.Bomb:
                                toWrite = emojiList[3];
                                break;
                        }
                        Console.Write(toWrite+" ");
                    }

                    Console.WriteLine();
                }
            }

            string GetSafeTileSprite(int[] coord)
            {
                string output = emojiList[1];  //default revealed tile, with no bombs.
                int bombCount = GetNearbyBombCount(coord);
                bool nearbyBombs = bombCount > 0; 
                if (nearbyBombs)
                {
                    output = numbList[bombCount];
                }
                
                return output;
            }

            int GetNearbyBombCount(int[] coord)
            {
                int bombs = 0;
                int row = coord[0];
                int column = coord[1]; 

                for (int rowOffset = -1; rowOffset <= 1; rowOffset++) // goes along the row
                {
                    for (int columnOffset = -1; columnOffset <= 1; columnOffset++) // goes along the column
                    {
                        if (rowOffset == 0 && columnOffset == 0) // this would be the coord tile, so skip.
                        {
                            continue; 
                        }
                        int nearbyRow = row + rowOffset;
                        int nearbyColumn = column + columnOffset;
                        
                        if (nearbyRow < 0 || nearbyRow >= grid.GetLength(0) || nearbyColumn < 0 || nearbyColumn >= grid.GetLength(1))
                        {
                            continue; // skip if out of bounds
                        }
                        
                        int[] nearbyCoord = {nearbyRow, nearbyColumn};
                        if (isTileBomb(nearbyCoord))
                        {
                            bombs++;
                        }
                        
                    }
                }
                return bombs;
            }

            bool isTileBomb(int[] coord)
            {
                return grid[coord[0],coord[1]] == MsValues.HiddenBomb || grid[coord[0],coord[1]] == MsValues.FlagHiddenBomb;
            }
        }
    }
}
