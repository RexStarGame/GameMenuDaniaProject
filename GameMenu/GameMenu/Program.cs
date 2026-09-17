
Main();
        static void Main()
        {
    Console.WriteLine("GAME MENU \n 1. MasterMind \n 2. Chess \n 3. Snake \n 4. Minesweeper");

    ConsoleKeyInfo menuSelect = Console.ReadKey(true);

    if (menuSelect.Key==ConsoleKey.D1)
    {
        Console.Clear();
        MainMastermind();
    }
    else if (menuSelect.Key == ConsoleKey.D2)
    {
        Console.Clear();
        Chess();
    }

    else if (menuSelect.Key==ConsoleKey.D4)
    {
        Console.Clear();
        PlayMineSweeper();
    }


        }


static void MainMastermind()
{
    string[] codeArray = new string[4];

    //string library of colors to choose from
    string[] colors = { "Red", "Green", "Blue", "Yellow", "White" };

    //array to store user input
    string[] userInputArray = new string[4];

    //randomly generate the codeArray with colors from the colors string
    for (int i = 0; i < codeArray.Length; i++)
    {
        codeArray.SetValue(colors[new Random().Next(colors.Length)], i);
    }

    Console.WriteLine($"{codeArray[0]} {codeArray[1]} {codeArray[2]} {codeArray[3]}");

    //start message to user
    Console.WriteLine("Welcome to MasterMind!");
    Console.WriteLine("The rules are simple: You have to guess the correct color code of 4 colors in 10 tries.");
    Console.WriteLine("You have 5 colors to choose from: Red, Green, Blue, Yellow and White");
    Console.WriteLine("Please provide the color code in the following manner for instance: Red,Green,Blue,Yellow");

    int counter = 0;

    //loop checking player input until all true or trials reach 10
    while (counter < 10)
    {

        bool inputOkay = false;

        while (inputOkay == false)
        {
            Console.WriteLine("Please enter guess: ");

            //get user input and and check for empty
            string userInput = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Please provide input");
                continue;
            }
            //split input by , into userInputArray
            userInputArray = userInput.Split(',');

            //check if all 4 places in array has been given value
            if (userInputArray.Length != 4)
            {
                Console.WriteLine("Incorrect answer method, please provide 4 inputs like so 1,2,3,4");
                continue;
            }

            //check each userInputArray if the input matches one of the colors in the color options or write failure message to user
            bool containsColor = colors.Any(color =>

            userInputArray[0].Contains(color, StringComparison.OrdinalIgnoreCase));


            if (!containsColor)
            {
                Console.WriteLine("Incorrect answer method, please provide 4 colors from the 5 mentioned options");
                continue;
            }

            bool containsColor1 = colors.Any(color =>

            userInputArray[1].Contains(color, StringComparison.OrdinalIgnoreCase));
            if (!containsColor1)
            {
                Console.WriteLine("Incorrect answer method, please provide 4 colors from the 5 mentioned options");
                continue;
            }

            bool containsColor2 = colors.Any(color =>
            userInputArray[2].Contains(color, StringComparison.OrdinalIgnoreCase));
            if (!containsColor2)
            {
                Console.WriteLine("Incorrect answer method, please provide 4 colors from the 5 mentioned options");
                continue;
            }

            bool ContainsColor3 = colors.Any(color =>
            userInputArray[3].Contains(color, StringComparison.OrdinalIgnoreCase));
            if (!ContainsColor3)
            {
                Console.WriteLine("Incorrect answer method, please provide 4 colors from the 5 mentioned options");
                continue;
            }

            if (ContainsColor3 == true)
                inputOkay = true;
        }

        Console.WriteLine($"Your guess: {userInputArray[0]}, {userInputArray[1]}, {userInputArray[2]}, {userInputArray[3]}");


        //compare the user input with the codeArray and print V for correct and X for incorrect
        int result1 = string.Compare(codeArray[0], userInputArray[0], true);
        int result2 = string.Compare(codeArray[1], userInputArray[1], true);
        int result3 = string.Compare(codeArray[2], userInputArray[2], true);
        int result4 = string.Compare(codeArray[3], userInputArray[3], true);

        if (result1 == 0)
        { Console.Write("V "); }
        else
        { Console.Write("X "); }
        if (result2 == 0)
        { Console.Write("V "); }
        else
        { Console.Write("X "); }
        if (result3 == 0)
        { Console.Write("V "); }
        else
        { Console.Write("X "); }
        if (result4 == 0)
        { Console.WriteLine("V "); }
        else
        { Console.WriteLine("X "); }

        //if all guesses are correct winner message will be provided
        if (result1 == 0 && result2 == 0 && result3 == 0 && result4 == 0)
        {
            Console.WriteLine("Congratulations, you have won \nPress ESC to GAME MENU \nPress ENTER to try again");

            ConsoleKeyInfo menuSelect = Console.ReadKey(true);

            if (menuSelect.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Main();
            }
            else if (menuSelect.Key==ConsoleKey.Enter)
            {
                Console.Clear();
                MainMastermind();
            }

        }

        counter++;


    }
    //if all 10 attempts have been used lost message will be given
    if (counter >= 9)
    {
        Console.WriteLine("Sorry you have lost \nPress ESC to GAME MENU \nPress ENTER to try again");
        ConsoleKeyInfo menuSelect = Console.ReadKey(true);



    }
    //if all 10 attempts have been used lost message will be given
    if (counter >= 9)
    {
        Console.WriteLine("Sorry you have lost \nPress ESC to GAME MENU \nPress ENTER to try again");
        ConsoleKeyInfo menuSelect = Console.ReadKey(true);

        if (menuSelect.Key == ConsoleKey.Escape)
        {
            Console.Clear();
            Main();
        }
        else if (menuSelect.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            MainMastermind();
        }
    }
}

static void Chess()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    int[,] multiArray = new int[8, 8];

    for (int col = 0; col < 8; col++)
    {
        //Grønne bønder
        multiArray[1, col] = 1;
    }
    //Grønne tårne
    multiArray[0, 0] = 2;
    multiArray[0, 7] = 2;
    //Grønne springere
    multiArray[0, 1] = 3;
    multiArray[0, 6] = 3;
    //Grønne løbere
    multiArray[0, 2] = 4;
    multiArray[0, 5] = 4;
    //Grøn konge
    multiArray[0, 3] = 5;
    //Grøn dronning
    multiArray[0, 4] = 6;

    for (int col = 0; col < 8; col++)
    {
        //Røde bønder
        multiArray[6, col] = 7;
    }
    //Røde tårne
    multiArray[7, 0] = 8;
    multiArray[7, 7] = 8;
    //Røde springere
    multiArray[7, 6] = 9;
    multiArray[7, 1] = 9;
    //Røde løbere
    multiArray[7, 5] = 10;
    multiArray[7, 2] = 10;
    //Rød konge
    multiArray[7, 3] = 11;
    //Rød dronning
    multiArray[7, 4] = 12;

    bool whiteTurn = true;
    bool gameOver = false;

    while (!gameOver)
    {
        Console.Clear();

        Console.WriteLine("Chess\n");

        if (whiteTurn)
        {
            Console.WriteLine("Green's turn\n");
        }
        else
        {
            Console.WriteLine("Red's turn\n");
        }

        //Chess board being created
        for (int row = 0; row < multiArray.GetLength(0); row++)
        {
            Console.Write((8 - row) + " ");

            for (int col = 0; col < multiArray.GetLength(1); col++)
            {
                if ((col + row) % 2 == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }

                if (multiArray[row, col] >= 1 && multiArray[row, col] <= 6)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (multiArray[row, col] >= 7 && multiArray[row, col] <= 12)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                //Green getting their pieces
                if (multiArray[row, col] == 1)
                {
                    Console.Write("♙ ");
                }
                else if (multiArray[row, col] == 2)
                {
                    Console.Write("♖ ");
                }
                else if (multiArray[row, col] == 3)
                {
                    Console.Write("♘ ");
                }
                else if (multiArray[row, col] == 4)
                {
                    Console.Write("♗ ");
                }
                else if (multiArray[row, col] == 5)
                {
                    Console.Write("♕ ");
                }
                else if (multiArray[row, col] == 6)
                {
                    Console.Write("♔ ");
                }
                //Red getting their pieces
                else if (multiArray[row, col] == 7)
                {
                    Console.Write("♙ ");
                }
                else if (multiArray[row, col] == 8)
                {
                    Console.Write("♖ ");
                }
                else if (multiArray[row, col] == 9)
                {
                    Console.Write("♘ ");
                }
                else if (multiArray[row, col] == 10)
                {
                    Console.Write("♗ ");
                }
                else if (multiArray[row, col] == 11)
                {
                    Console.Write("♕ ");
                }
                else if (multiArray[row, col] == 12)
                {
                    Console.Write("♔ ");
                }
                else
                {
                    Console.Write("  ");
                }

                Console.ResetColor();
            }
            Console.WriteLine();
        }
        Console.Write("  ");

        for (char col = 'A'; col <= 'H'; col++)
        {
            Console.Write(col + " ");
        }
        Console.WriteLine();
        Console.Write("\nFrom: ");
        string from = Console.ReadLine() ?? "";

        Console.Write("To: ");
        string to = Console.ReadLine() ?? "";

        char fromCol = from[0];
        char fromRow = from[1];

        char toCol = to[0];
        char toRow = to[1];

        int fromColNum = fromCol - 'A';
        int toColNum = toCol - 'A';

        int fromRowNum = 8 - (fromRow - '0');
        int toRowNum = 8 - (toRow - '0');

        int piece = multiArray[fromRowNum, fromColNum];
        int targetPiece = multiArray[toRowNum, toColNum];

        if (targetPiece == 11 && whiteTurn)
        {
            Console.WriteLine("\nGreen wins!\nPress ESC to GAME MENU \nPress ENTER to try again");
            gameOver = true;
            ConsoleKeyInfo menuSelect = Console.ReadKey(true);

            if (menuSelect.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Main();
            }
            else if (menuSelect.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Chess();
            }
        }
        else if (targetPiece == 5 && !whiteTurn)
        {
            Console.WriteLine("\nRed wins!\nPress ESC to GAME MENU \nPress ENTER to try again");
            gameOver = true;
            ConsoleKeyInfo menuSelect = Console.ReadKey(true);

            if (menuSelect.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Main();
            }
            else if (menuSelect.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Chess();
            }
        }

        if (gameOver)
        {
            break;
        }

        if (piece == 0)
        {
            Console.WriteLine("There is no piece on this position");
            Console.ReadKey();
            continue;
        }

        multiArray[toRowNum, toColNum] = piece;
        multiArray[fromRowNum, fromColNum] = 0;
        whiteTurn = !whiteTurn;

        Console.WriteLine("You have moved from " + from + " to " + to);
    }
}








/// <summary>
/// Mine Sweeper tile values.
/// </summary>

// MINESWEEPER BELLOW --------------------------------------------------------
static void PlayMineSweeper()
{

const int bombCount = 40;
    string[] emojiList = { "⬛", "⬜", "🚩", "💣" };
    string[] numbList = { "0 ", "1 ", "2 ", "3 ", "4 ", "5 ", "6 ", "7 ", "8 " };
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
        Console.WriteLine("What would you like to do at (" + coordColumn + "." + coordRow + ")?");
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
        MsValues[,] newGrid = new MsValues[gridSize, gridSize];
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
                SetTileValue(tileCoord, MsValues.HiddenBomb);
                b++;
            }

        }
        Console.WriteLine("Generated bombs.");
    }

    int[] PickRandomTile()
    {
        int x = random.Next(0, gridSize);
        int y = random.Next(0, gridSize);
        return new int[] { x, y }; //Coordinate

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
                SetTileValue(coord, MsValues.Safe);
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
            SetTileValue(coord, MsValues.FlagHiddenBomb);
        }
        else if (tileValue == MsValues.FlagHiddenBomb)
        {
            SetTileValue(coord, MsValues.HiddenBomb);
        }
        else if (tileValue == MsValues.HiddenSafe)
        {
            SetTileValue(coord, MsValues.FlagHiddenSafe);
        }
        else if (tileValue == MsValues.FlagHiddenSafe)
        {
            SetTileValue(coord, MsValues.HiddenSafe);
        }
    }

    MsValues GetTileValue(int[] coord)
    {
        return grid[coord[0], coord[1]];
    }

    void SetTileValue(int[] coord, MsValues newValue)
    {
        grid[coord[0], coord[1]] = newValue;
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
        SetTileValue(coord, MsValues.Bomb);
        DrawGrid();
        Console.WriteLine("                             ____\n                     __,-~~/~    `---.\n                   _/_,---(      ,    )\n               __ /        <    /   )  \\___\n- ------===;;;'====------------------===;;;===----- -  -\n                  \\/  ~\"~\"~\"~\"~\"~\\~\"~)~\"/\n                  (_ (   \\  (     >    \\)\n                   \\_( _ <         >_>'\n                      ~ `-i' ::>|--\"\n                          I;|.|.|\n                         <|i::|i|`.\n                        (` ^'\"`-' \")\n");
        Console.WriteLine("YOU LOSE! :(");
        Console.WriteLine("Press ENTER to retry \nPress ESC to GAME MENU");
        ConsoleKeyInfo menuSelect = Console.ReadKey(true);


        if (menuSelect.Key == ConsoleKey.Escape)
        {
            Console.Clear();
            Main();
        }
        else if (menuSelect.Key == ConsoleKey.Enter)
        {
            Console.Clear();

            MainMastermind();

            PlayMineSweeper();
        }
    }

    void GameWin()
    {
        Console.WriteLine("YOU WIN! \nPress ENTER to retry \nPress ESC to GAME MENU");

        ConsoleKeyInfo menuSelect = Console.ReadKey(true);

        if (menuSelect.Key == ConsoleKey.Escape)
        {
            Console.Clear();
            Main();
        }
        else if (menuSelect.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            PlayMineSweeper();
        }
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
                switch (value)
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
                Console.Write(toWrite + " ");
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

                int[] nearbyCoord = { nearbyRow, nearbyColumn };
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
        return grid[coord[0], coord[1]] == MsValues.HiddenBomb || grid[coord[0], coord[1]] == MsValues.FlagHiddenBomb;
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

                int[] nearbyCoord = { nearbyRow, nearbyColumn };

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





