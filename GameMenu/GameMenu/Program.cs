using System.ComponentModel.Design;

Main();
        static void Main()
        {
    Console.WriteLine("GAME MENU \n 1. MasterMind \n 2. Chess \n 3. Snake \n 4. Minesweeper");

    ConsoleKeyInfo menuSelect = Console.ReadKey(true);

    if (menuSelect.Key==ConsoleKey.D1)
    {
        Console.Clear();
        MainMastermind(); // <- Isabella
    }
    else if (menuSelect.Key == ConsoleKey.D2)
    {
        Console.Clear();
        Chess();          // <- Kasper
    }
    else if (menuSelect.Key == ConsoleKey.D3)
    {
        Console.Clear();
        SnakeGameRamme(); // <- Patrick
    }

    else if (menuSelect.Key==ConsoleKey.D4)
    {
        Console.Clear();
        PlayMineSweeper(); // <- Laurids
    }


        }


static void MainMastermind()
{
    string[] codeArray = new string[4];

    //string library of colors to choose from
    string[] colors = { "Red", "Green", "Blue", "Yellow", "White", "Pink" };

    //array to store user input
    string[] userInputArray = new string[4];

    //randomly generate the codeArray with colors from the colors string
    for (int i = 0; i < codeArray.Length; i++)
    {
        codeArray.SetValue(colors[new Random().Next(colors.Length)], i);
    }

    //to write out gererated secret code during creation of game
   // Console.WriteLine($"{codeArray[0]} {codeArray[1]} {codeArray[2]} {codeArray[3]}");

    //start message to user
    Console.WriteLine("Welcome to MasterMind!");
    Console.WriteLine("The rules are simple: You have to guess the correct color code of 4 colors in 10 tries.");
    Console.WriteLine("You have 6 colors to choose from: Red, Green, Blue, Yellow, White and Pink");
    Console.WriteLine("Please provide the color code in the following manner for instance: Red,Green,Blue,Yellow");

    //int counter for number of tries and counter for tries left
    int counter = 0;
    int countDownM = 10;

    //loop checking player input until all true or number of trials reach 10
    while (counter < 10)
    {
        //loop who checks input from user, so spelling mistakes or missing a color does not count in number of tries
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
            //split input by "," into userInputArray
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
                Console.WriteLine("Incorrect answer method, please provide 4 colors from the 6 mentioned options");
                continue;
            }

            bool containsColor1 = colors.Any(color =>

            userInputArray[1].Contains(color, StringComparison.OrdinalIgnoreCase));
            if (!containsColor1)
            {
                Console.WriteLine("Incorrect answer method, please provide 4 colors from the 6 mentioned options");
                continue;
            }

            bool containsColor2 = colors.Any(color =>
            userInputArray[2].Contains(color, StringComparison.OrdinalIgnoreCase));
            if (!containsColor2)
            {
                Console.WriteLine("Incorrect answer method, please provide 4 colors from the 6 mentioned options");
                continue;
            }

            bool ContainsColor3 = colors.Any(color =>
            userInputArray[3].Contains(color, StringComparison.OrdinalIgnoreCase));
            if (!ContainsColor3)
            {
                Console.WriteLine("Incorrect answer method, please provide 4 colors from the 6 mentioned options");
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
        countDownM--;
        Console.WriteLine($"Attempts left:{countDownM}");


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
        //Green Pawns
        multiArray[1, col] = 1;
        //Green Rooks
        multiArray[0, 0] = 2;
        multiArray[0, 7] = 2;
        //Green Knights
        multiArray[0, 1] = 3;
        multiArray[0, 6] = 3;
        //Green Bishops
        multiArray[0, 2] = 4;
        multiArray[0, 5] = 4;
        //Green King
        multiArray[0, 3] = 5;
        //Green Queen
        multiArray[0, 4] = 6;

        //Red Pawns
        multiArray[6, col] = 7;
        //Red Rooks
        multiArray[7, 0] = 8;
        multiArray[7, 7] = 8;
        //Red Knights
        multiArray[7, 6] = 9;
        multiArray[7, 1] = 9;
        //Red Bishops
        multiArray[7, 5] = 10;
        multiArray[7, 2] = 10;
        //Red King
        multiArray[7, 3] = 11;
        //Red Queen
        multiArray[7, 4] = 12;
    }

    bool greenTurn = true;
    bool gameOver = false;
    string lastMove = "";

    while (!gameOver)
    {
        Console.Clear();

        Console.WriteLine(@"  ____ _                   ");
        Console.WriteLine(@" / ___| |__   ___  ___ ___ ");
        Console.WriteLine(@"| |   | '_ \ / _ \/ __/ __|");
        Console.WriteLine(@"| |___| | | |  __/\__ \__ \");
        Console.WriteLine(@" \____|_| |_|\___||___/___/");

        Console.WriteLine("\nPlease type a letter from A - H followed by a number from 1 - 8");

        if (greenTurn)
        {
            Console.WriteLine("\nTurn: Green\n");
        }
        else
        {

            Console.WriteLine("\nTurn: Red\n");
        }

        //Drawing Chessboard
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
                //Colors for Green
                if (multiArray[row, col] >= 1 && multiArray[row, col] <= 6)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                //Colors for Red
                else if (multiArray[row, col] >= 7 && multiArray[row, col] <= 12)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                //Green converts to pieces
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
                //Red converts to pieces
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
        Console.WriteLine("\n" + lastMove);

        string from;
        string to;

        //Accepted inputs for "From"
        while (true)
        {
            Console.Write("From: ");
            from = Console.ReadLine() ?? "";

            if (from.Length != 2)
            {
                Console.WriteLine("Wrong input");
                continue;
            }

            if (!"ABCDEFGH".Contains(from[0]) || !"12345678".Contains(from[1]))
            {
                Console.WriteLine("Wrong input");
                continue;
            }

            break;
        }

        //Accepted inputs for "To"
        while (true)
        {
            Console.Write("To: ");
            to = Console.ReadLine() ?? "";

            if (to.Length != 2)
            {
                Console.WriteLine("Wrong input");
                continue;
            }

            if (!"ABCDEFGH".Contains(to[0]) || !"12345678".Contains(to[1]))
            {
                Console.WriteLine("Wrong input");
                continue;
            }

            break;
        }

        //Converts "From" and "To" input from the player
        char fromCol = from[0];
        char fromRow = from[1];

        char toCol = to[0];
        char toRow = to[1];

        //Converts chess coordinates (A-H and 1-8) to array indexes (0-7)
        int fromColNum = fromCol - 'A';
        int toColNum = toCol - 'A';

        int fromRowNum = 8 - (fromRow - '0');
        int toRowNum = 8 - (toRow - '0');

        //Gets the piece at the starting position to check for a valid or invalid move
        int piece = multiArray[fromRowNum, fromColNum];

        //Gets the piece at the destination to check if a King is captured
        int targetPiece = multiArray[toRowNum, toColNum];

        //Checking if move is invalid
        if (piece == 0)
        {
            Console.WriteLine("There is no piece on this position");
            Console.ReadKey();
            continue;
        }

        //Updates the board by moving the piece to the new position and clearing the old field
        multiArray[toRowNum, toColNum] = piece;
        multiArray[fromRowNum, fromColNum] = 0;

        //If Green wins Chess
        if (targetPiece == 11 && greenTurn)
        {
            Console.WriteLine("\nGreen wins!\n" + "\nPress ESC to GAME MENU\nPress ENTER to try again");
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
        //If Red wins Chess
        else if (targetPiece == 5 && !greenTurn)
        {
            Console.WriteLine("\nRed wins!\n" + "\nPress ESC to GAME MENU\nPress ENTER to try again");
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

        //Switches the turn to the other player
        greenTurn = !greenTurn;

        //Player moves
        if (!greenTurn)
        {
            lastMove = ("\nGreen moved from " + from + " to " + to);
        }
        else
        {
            lastMove = ("\nRed moved from " + from + " to " + to);
        }
    }
}

/// <SnakeGame>
/// et spil hvor du styr en slange og skal forsøge at vokse sig stor uden at dø....
/// <SnakeGame>
static void SnakeGameRamme()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8; //Allow the console to use unicode emojis/symboler, but i did not manage to find away to fix the following issues for this yet.
    Console.CursorVisible = false; // hides the arrow that shows where you tpye next. (hard to discibe what this dose) 

    string[,] stringArray = new string[30, 40];

    int lastRowY = stringArray.GetUpperBound(0); // sidste gyldige indext som i kan få
    int lastColumnX = stringArray.GetUpperBound(1); // sidste gyldige indext som j kan få

    for (int i = 0; i < stringArray.GetLength(0); i++)
    {
        for (int j = 0; j < stringArray.GetLength(1); j++)
        {
            if (i == 0 || j == 0 || i == lastRowY || j == lastColumnX) // øverst i højre eller øverst venstre kollone væg, eller neders bundt.
            {
                stringArray[i, j] = "#"; // vægsymboler.
            }
            else
            {
                stringArray[i, j] = " "; // tom plads.

            }
            Console.Write(stringArray[i, j]);
        }
        Console.WriteLine();
    }

    SnakeBody('■', '@', stringArray, true, lastRowY, lastColumnX); // call SnakeBody().

    static void SnakeBody(char snakeTail, char snakeHead, string[,] stringArray, bool isAktiv, int lastRowY, int lastColumnX)
    {
        char keyboard = 's';

        int snakeX = 10; // current X posision of the snake in stringArray[row, col]. this is col
        int snakeY = 10; // current Y posision of the snake in stringArray[row, col]. this is row

        int snakeoldPossionX;
        int snakeoldPossionY; // old Y pasision of snakeHead, used to transfrom the old head position into (snakeTail)

        int[] snakeTailPositionsX = new int[100];
        int[] snakeTailPositionsY = new int[100]; // snakeTail max 100 tail parts, 0-99 index. 


        bool[] maxAppleSpawn = new bool[3];
        bool playerEateApple = false; // spilleren har ikke spidst lige pt :) 
        bool applePosisionisFree = false; // checks if Apples posision is free or orgipaid.
        bool playerAlive = true; // spilleren starter med at være ilive. 

        Random appleRandomLocation = new Random();


        int[] appleLocationX = new int[3];
        int[] appleLocationY = new int[3];

        int currentApple = 0;

        int snakeLength = 2;

        stringArray[snakeY, snakeX] = snakeHead.ToString();

        snakeTailPositionsY[0] = snakeY - 1;
        snakeTailPositionsX[0] = snakeX;
        while (!Console.KeyAvailable)
        {
            Thread.Sleep(800); // fortæller computuren at skal hole en pause i 800 mili sec før den læser videre.
            Console.SetCursorPosition(3, 10);
            Console.Write("tyk på noget for at starte\n   spillet"); // show text
            Thread.Sleep(800); // pause 800 mili sec
            Console.SetCursorPosition(3, 10);
            Console.Write("                          \n          "); // removes the old text.
        }

        ConsoleKeyInfo keyTouch = Console.ReadKey(true); // ved godt det ikke er optimalt måde at gøre det på jeg bruger den til at lave et pause er du klar? da vi aligevel skal bruge dette KeyTouch senere i koden.

        while (isAktiv)
        {
            playerEateApple = false; // i starten af frame siger vi at spilleren ikke har spidst og ændres kun vis den spiser et æble selv i starten af dette frame.
            if (Console.KeyAvailable)
            {
                keyboard = Console.ReadKey(true).KeyChar; // only read inputs if any key is available. 
            }
            snakeoldPossionY = snakeY;
            snakeoldPossionX = snakeX;

            Thread.Sleep(250);

            int tailEdgeY = snakeTailPositionsY[snakeLength - 2]; // enden af halen Y
            int tailEdgeX = snakeTailPositionsX[snakeLength - 2]; // enden af halen X

            stringArray[snakeoldPossionY, snakeoldPossionX] = snakeTail.ToString();
            Console.SetCursorPosition(snakeoldPossionX, snakeoldPossionY);
            Console.Write(snakeTail);

            switch (keyboard)
            {
                case 'a':

                    snakeX--; // moving to the left by 1 int/posision on every frame/tick

                    break;

                case 'd':

                    snakeX++; // right

                    break;

                case 'w':

                    snakeY--; // up

                    break;

                case 's':

                    snakeY++; // down 

                    break;
            }
           

            if (snakeX >= lastColumnX || snakeY >= lastRowY || snakeY <= 0 || snakeX <= 0) // checks if player colides with the wall and dies :) 
            {
                playerAlive = false; // spilleren er død
            }
            for (int h = 0; h < snakeLength - 1; h++) // check every tail parts in SnakeLength
            {
                if (snakeX == snakeTailPositionsX[h] && snakeY == snakeTailPositionsY[h]) // checks if snakeHead collides with our snakeTail.
                {
                    playerAlive = false;
                }
            }
            if(!playerAlive) // ser om spilleren er ilive eller ej.
            {
                Console.WriteLine(
                    "    du døde tyk på (Enter) vis du ønsker at\n " +
                    "    prøve spillet igen \n " +
                    "    tyk på EXC for at gå til menu");
                keyTouch = Console.ReadKey();
                while(keyTouch.Key != ConsoleKey.Enter && keyTouch.Key != ConsoleKey.Escape)
                {
                    keyTouch = Console.ReadKey(true);         
                }
                if (keyTouch.Key == ConsoleKey.Enter)
                {
                    isAktiv = false;
                    Console.Clear();
                    SnakeGameRamme(); // Spillet starter igen.
                    return; // skal siges return torede jeg ikke kunne bruges i et void xD men jeg tog fejl xD
                }
                else if (keyTouch.Key == ConsoleKey.Escape)
                {
                    isAktiv = false;
                    Console.Clear();
                    Main(); // går tilbage til menu. oggså selvom (return) ville gå til SnakeGameRamme() xD
                    return; // stopper SnakeBody() med det samme og går tilbage til den der kaldte SnakeBody() xD ikke main() xD.
                }
            }

            Console.SetCursorPosition(snakeX, snakeY);
            Console.Write(snakeHead);

            for (int s = 0; s < maxAppleSpawn.Length; s++)
            {

                if (appleLocationY[s] == snakeY && appleLocationX[s] == snakeX && maxAppleSpawn[s] == true) // if snakehead reaches an apple location
                {
                    snakeLength++;
                    stringArray[appleLocationY[s], appleLocationX[s]] = " ";
                    playerEateApple = true; // player has eaten the apple
                    currentApple++; // adds 1+ for each apple player has eaten. 
                    maxAppleSpawn[s] = false;
                    continue;
                }
                if (maxAppleSpawn[s] == false)
                {
                    applePosisionisFree = false;

                    while (applePosisionisFree == false) // bruges til at sikker at vi aldrig spawner et andet æble aller hale eller hovedet af slangen i samme location.
                    {
                        appleLocationY[s] = appleRandomLocation.Next(5, lastRowY); // creating a new random location for our next apple.
                        appleLocationX[s] = appleRandomLocation.Next(5, lastColumnX);

                        applePosisionisFree = true;

                        for (int h = 0; h < snakeLength - 1; h++) // checks if the new apple spawns on the snake head
                        {
                            if (appleLocationX[s] == snakeTailPositionsX[h] && appleLocationY[s] == snakeTailPositionsY[h])
                            {
                                applePosisionisFree = false;
                            }
                        }

                        if (appleLocationX[s] == snakeX && appleLocationY[s] == snakeY) // checks if the new apple spawns on the snake head
                        {
                            applePosisionisFree = false;
                        }
                        for (int w = 0; w < maxAppleSpawn.Length; w++) // checks if the new apple spawns on top of another active apple
                        {
                            if (w != s && maxAppleSpawn[w] == true)
                            {
                                if (appleLocationX[s] == appleLocationX[w] && appleLocationY[s] == appleLocationY[w])
                                {
                                    applePosisionisFree = false;
                                }
                            }
                        }
                    }
                    stringArray[appleLocationY[s], appleLocationX[s]] = "●"; // food/apple
                    Console.SetCursorPosition(appleLocationX[s], appleLocationY[s]);
                    Console.Write("●");
                    maxAppleSpawn[s] = true;
                    continue;
                }
            }

            if (snakeLength < snakeTailPositionsX.Length && snakeLength < snakeTailPositionsY.Length)
            {
                for (int a = snakeLength - 2; a > 0; a--)
                {
                    snakeTailPositionsX[a] = snakeTailPositionsX[a - 1];
                    snakeTailPositionsY[a] = snakeTailPositionsY[a - 1];
                }
                snakeTailPositionsX[0] = snakeoldPossionX;
                snakeTailPositionsY[0] = snakeoldPossionY;
                stringArray[snakeY, snakeX] = snakeHead.ToString();
                Console.SetCursorPosition(snakeX, snakeY);
                Console.Write(snakeHead);

                if (tailEdgeY != 0 && tailEdgeX != 0 && playerEateApple == false) // if not player have eaten the apple and our tail posision is not = 0 then continue.
                {
                    stringArray[tailEdgeY, tailEdgeX] = " "; // remove old tails posision from stringArray
                    Console.SetCursorPosition(tailEdgeX, tailEdgeY); // set possion to our cursor to be our old tails posision. 
                    Console.Write(" "); // remove old tail visualt so you no longer can see it. 
                }

                Console.SetCursorPosition(42, 2); // vælger en spesisfic plasering til at vise længten live for spilleren. 
                Console.Write($" slangens længte {snakeLength}");
                Console.SetCursorPosition(42, 3); // vælger en spesisfic plasering til at vise antal æbler live for spilleren. 
                Console.Write($"antal æbler spist {currentApple}");
            }
        }
    }
}



// MINESWEEPER BELLOW --------------------------------------------------------
static void PlayMineSweeper()
{
    bool isGameOver = false;
    const int gridSize = 9; // how big is the 1:1 grid
    const int bombCount = 10; // how many bombs
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
        Console.WriteLine("Press 'Esc' to return to menu, or 'Enter' to try again.");
        
        ConsoleKeyInfo menuSelect = Console.ReadKey(true);
        Console.ResetColor();
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


    void GameWin()
    {
        DrawGrid();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("");
        Console.WriteLine("There are no more mines!!");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("██    ██  ██████  ██    ██     ██     ██ ██ ███    ██ ██ \n ██  ██  ██    ██ ██    ██     ██     ██ ██ ████   ██ ██ \n  ████   ██    ██ ██    ██     ██  █  ██ ██ ██ ██  ██ ██ \n   ██    ██    ██ ██    ██     ██ ███ ██ ██ ██  ██ ██    \n   ██     ██████   ██████       ███ ███  ██ ██   ████ ██ \n                                                         \n                                                         ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Press 'Esc' to return to menu, or 'Enter' to play again!");
        Console.ResetColor();
        
        ConsoleKeyInfo menuSelect = Console.ReadKey(true);
        Console.ResetColor();
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





