namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("        Skak\n");
            int[,] multiArray = new int[8, 8];

            for (int col = 0; col < 8; col++)
            {
                //Hvide bønder
                multiArray[1, col] = 1;
                //Sorte bønder
                multiArray[6, col] = 1;
            }
            //Hvide tårne
            multiArray[0, 0] = 2;
            multiArray[0, 7] = 2;
            //Sorte tårne
            multiArray[7, 0] = 2;
            multiArray[7, 7] = 2;

            //Hvide springere
            multiArray[0, 1] = 3;
            multiArray[0, 6] = 3;
            //Sorte springere
            multiArray[7, 6] = 3;
            multiArray[7, 1] = 3;

            //Hvide løbere
            multiArray[0, 2] = 4;
            multiArray[0, 5] = 4;
            //Sorte løbere
            multiArray[7, 5] = 4;
            multiArray[7, 2] = 4;

            //Hvid konge
            multiArray[0, 3] = 5;
            //Hvid dronning
            multiArray[0, 4] = 6;

            //Sort konge
            multiArray[7, 3] = 7;
            //Sort dronning
            multiArray[7, 4] = 8;

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

                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    //Tal bliver lavet om til brikker
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
                    else if (multiArray[row, col] == 7)
                    {
                        Console.Write("♕ ");
                    }
                    else if (multiArray[row, col] == 8)
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
        }
    }
}