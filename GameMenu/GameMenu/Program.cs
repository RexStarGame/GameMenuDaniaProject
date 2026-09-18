PlayMineSweeper(args);

// MINESWEEPER BELLOW --------------------------------------------------------
void PlayMineSweeper(string[] args)
{
    bool isGameOver = false;
    const int gridSize = 9; // how big is the 1:1 grid
    const int bombCount = 1; // how many bombs
    const ConsoleColor headerColour = ConsoleColor.Yellow;
    int remainingBombs = bombCount;
    int remainingHiddenSafe = (gridSize*gridSize-bombCount);
    string[] emojiList = {"⬛","⬜","🚩","💣"};
    string[] numbList = { "0 ","1 ", "2 ", "3 ", "4 ", "5 ", "6 ", "7 ", "8 " };
    Random random = new Random();
    MsValues[,] grid = GenerateGameBoard();
    GenerateBombs(grid);
    
    RequestInput();

    void RequestInput()
    {
        if (remainingBombs == 0 && remainingHiddenSafe==0)
        {
            GameWin();
            return;
        }
        DrawGrid();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Choose a tile..");
        Console.ResetColor();
        
        Console.Write("X = ");
        string inputX = Console.ReadLine();
        if (!int.TryParse(inputX, out int coordColumn) || coordColumn-1 > gridSize || coordColumn-1 < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(inputX+" is an invalid X coordinate.");
            Console.ResetColor();
            RequestInput();
            return;
        }
        Console.Write("Y = ");
        string inputY = Console.ReadLine();
        if (!int.TryParse(inputY, out int coordRow) || coordRow-1 > gridSize || coordRow-1 < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(inputY+" is an invalid Y coordinate.");
            Console.ResetColor();
            RequestInput();
            return;
        }
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        int[] coord = [coordRow-1, coordColumn-1];
        Console.WriteLine("What would you like to do at ("+ (coordColumn )+"."+ (coordRow)+")?");
        Console.ResetColor();
        Console.WriteLine("   1. Reveal the tile.🔎");
        Console.WriteLine("   2. Flag/unflag the tile.🚩");
        Console.WriteLine("   3. Pick a different tile.❌");
        string action = Console.ReadLine() ?? ""; // ?? "" Allows for invalid inputs to go to the 'default'
        switch (action)
        {
            case "1": // reveal tile
                if (IsTileHidden(coord) is false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(("TILE IS ALREADY REVEALED"));
                    Console.ResetColor();
                    RequestInput();
                    break;
                }
                if (IsTileFlagged(coord))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(("CANNOT REVEAL TILE, TILE IS FLAGGED"));
                    Console.ResetColor();
                    RequestInput();
                    break;
                }
                MsValues tileValue = RevealTile(coord);
                if (tileValue != MsValues.HiddenBomb)
                {
                    RequestInput();
                }
                break;
            case "2": // Flag tile
                if (IsTileHidden(coord) is false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(("TILE CANNOT BE FLAGGED"));
                    Console.ResetColor();
                    RequestInput();
                    break;
                }
                FlagTile(coord);
                RequestInput();
                break;
            case "3": // Pick different tile
                RequestInput();
                break;
            default: // invalid input
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(("INVALID INPUT"));
                Console.ResetColor();
                RequestInput();
                break;
        }
    }

    MsValues[,] GenerateGameBoard()
    {
        MsValues[,] newBoard = GenerateGrid();
        return newBoard;
    }
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
            RevealSafeNeighbors(coord);
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
        MsValues oldValue = grid[coord[0], coord[1]];
        grid[coord[0],coord[1]] = newValue;
        if (oldValue == MsValues.FlagHiddenBomb || oldValue == MsValues.HiddenBomb)
        {
            if (oldValue == MsValues.HiddenBomb && newValue == MsValues.FlagHiddenBomb)
            {
                remainingBombs--; // remove bomb from count.
            }
            else if (oldValue == MsValues.FlagHiddenBomb && newValue == MsValues.HiddenBomb)
            {
                remainingBombs++; // add bomb to count.
            }
        }
        else if (oldValue == MsValues.HiddenSafe)
        {
            if (oldValue == MsValues.HiddenSafe && newValue == MsValues.Safe)
            {
                remainingHiddenSafe--; // remove safe from count.
            }
            else if (oldValue == MsValues.Safe && newValue == MsValues.HiddenSafe)
            {
                remainingHiddenSafe++; // add safe to count.
            }
        }
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
        isGameOver = true;
        DrawGrid();

        Console.ForegroundColor = ConsoleColor.DarkRed;

        Console.WriteLine("""
                                                       ____
                                               __,-~~/~    `---.
                                             _/_,---(      ,    )
                                         __ /        <    /   )  \___
                          - ------===;;;'====------------------===;;;===----- -  -
                                            \/  ~"~"~"~"~"~\~"~)~"/
                                            (_ (   \  (     >    \)
                                             \_( _ <         >_>'
                                                ~ `-i' ::>|--"
                                                    I;|.|.|
                                                   <|i::|i|.
                                                  (` ^'"`-' ")
                          """);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("░████████     ░██████     ░██████     ░██████   ░███     ░███ ░██ \n░██    ░██   ░██   ░██   ░██   ░██   ░██   ░██  ░████   ░████ ░██ \n░██    ░██  ░██     ░██ ░██     ░██ ░██     ░██ ░██░██ ░██░██ ░██ \n░████████   ░██     ░██ ░██     ░██ ░██     ░██ ░██ ░████ ░██ ░██ \n░██     ░██ ░██     ░██ ░██     ░██ ░██     ░██ ░██  ░██  ░██ ░██ \n░██     ░██  ░██   ░██   ░██   ░██   ░██   ░██  ░██       ░██     \n░█████████    ░██████     ░██████     ░██████   ░██       ░██ ░██ \n                                                                  \n                                                                  \n                                                                  ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Oops! That was a mine! YOU LOSE! :(");

        Console.ResetColor();
    }


    void GameWin()
    {
        DrawGrid();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("");
        Console.WriteLine("There are no more mines!!");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("██    ██  ██████  ██    ██     ██     ██ ██ ███    ██ ██ \n ██  ██  ██    ██ ██    ██     ██     ██ ██ ████   ██ ██ \n  ████   ██    ██ ██    ██     ██  █  ██ ██ ██ ██  ██ ██ \n   ██    ██    ██ ██    ██     ██ ███ ██ ██ ██  ██ ██    \n   ██     ██████   ██████       ███ ███  ██ ██   ████ ██ \n                                                         \n                                                         ");
        Console.ResetColor();
    }

    void DrawGrid()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("There are " + bombCount +" mines. Flag them all to win!");
        Console.ResetColor();
        int rows = grid.GetLength(0);
        int columns = grid.GetLength(1);
        // Header color
        Console.ForegroundColor = headerColour;
        // Column headers
        Console.Write("  ");
        for (int c = 0; c < columns; c++)
        {
            Console.Write($"{c+1,3}");
        }
        Console.WriteLine();
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            // Row headers
            Console.ForegroundColor = headerColour;
            Console.Write($"{x+1,3}");
            Console.ResetColor();
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
                        if (isGameOver)
                        {
                            toWrite = emojiList[3];
                            break;
                        }
                        toWrite = emojiList[0];
                        break;
                    case MsValues.FlagHiddenBomb:
                        if (isGameOver)
                        {
                            toWrite = emojiList[3];
                            break;
                        }
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
    
    // Reveals all neighbors with 0 nearby bombs, as well as the 8 adjacent tiles.
    void RevealSafeNeighbors(int[] coord)
    {
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
                
                // Skip flags and bombs
                if (GetTileValue(nearbyCoord) != MsValues.HiddenSafe)
                {
                    continue;
                }
                // Reveal every adjacent safe tile, including numbered tiles.
                SetTileValue(nearbyCoord, MsValues.Safe);

                // Continue spreading only through non-bomb tiles.
                if (GetNearbyBombCount(nearbyCoord) == 0)
                {
                    RevealSafeNeighbors(nearbyCoord);
                }

            }
        }
    }
}
enum MsValues
{
    HiddenSafe = 0,
    Safe = 1,
    FlagHiddenSafe = 2,
    HiddenBomb = 3,
    FlagHiddenBomb = 4,
    Bomb = 5
};
