using System.Diagnostics.Metrics;

namespace GameMenu
{
    internal class Program
    {
        static void Main(string[] args)
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

                Console.WriteLine("Please enter guess: ");

                //get user input and split it into an array
                string userInput = Console.ReadLine();
                userInputArray = userInput.Split(',');

                Console.WriteLine($"Your guess: {userInputArray[0]}, {userInputArray[1]}, {userInputArray[2]}, {userInputArray[3]}");

                //compare the user input with the codeArray and print V for correct and X for incorrect
                int result1 = string.Compare(codeArray[0], userInputArray[0], true);
                int result2 = string.Compare(codeArray[1], userInputArray[1], true);
                int result3 = string.Compare(codeArray[2], userInputArray[2], true);
                int result4 = string.Compare(codeArray[3], userInputArray[3], true);

                if (result1 == 0)
                { Console.WriteLine("V"); }
                else
                { Console.WriteLine("X"); }
                if (result2 == 0)
                { Console.WriteLine("V"); }
                else
                { Console.WriteLine("X"); }
                if (result3 == 0)
                { Console.WriteLine("V"); }
                else
                { Console.WriteLine("X"); }
                if (result4 == 0)
                { Console.WriteLine("V"); }
                else
                { Console.WriteLine("X"); }

                //if all guesses are correct winner message will be provided
                if (result1==0 && result2==0 && result3==0 && result4==0)
                { Console.WriteLine("Congratulations, you have won");
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
    }
}
