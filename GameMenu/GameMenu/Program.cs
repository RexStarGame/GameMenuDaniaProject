namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
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

                        //Grønne brikker
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
                        //Røde brikker
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
                string from = Console.ReadLine();

                Console.Write("To: ");
                string to = Console.ReadLine();

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
                    Console.WriteLine("\nGreen wins!");
                    gameOver = true;
                    Console.ReadKey();
                }
                else if (targetPiece == 5 && !whiteTurn)
                {
                    Console.WriteLine("\nRed wins!");
                    gameOver = true;
                    Console.ReadKey();
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
    }
}