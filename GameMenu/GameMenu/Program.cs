using System.Diagnostics.Metrics;
using System.Drawing;

MainMastermind();
static void MainMastermind()
        {
            string[] codeArray = new string[4];

            //string library of colors to choose from
            string[] colors = { "Red", "Green", "Blue", "Yellow" , "White" };

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
                        Console.WriteLine("Congratulations, you have won");
                        Console.ReadKey();
                        break;
                    }

                    counter++;
                
        
            }
            //if all 10 attempts have been used lost message will be given
            if (counter == 9)
            {
                Console.WriteLine("Sorry you have lost");
            }
            else
            {
                Console.ReadKey();
            }

        }
   
