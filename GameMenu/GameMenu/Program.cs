
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



