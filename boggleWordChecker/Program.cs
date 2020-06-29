using System;
using System.Text.Json.Serialization;
using System.Threading;

namespace boggleWordChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] boggleGrid = { { "I", "L", "A", "W" } ,
                                     { "B","N","G","E" },
                                     { "I","U","A","O"},
                                     { "A","S","R","L"} };

        Console.WriteLine("Hello World!");
            Console.WriteLine(boggleWordChecker(boggleGrid, "ILNBIA"));
        }

        public static bool boggleWordChecker(char[,] board, string word)
        {
            //split the string
            //find the first letter
            //check letters around it
            //if they match, move on one letter.
            bool result = false;

            char[] lettersToCheck = word.ToCharArray();
            
            for(int letterCount = 0; letterCount < lettersToCheck.Length -1; letterCount++)
            {
                Console.WriteLine("letter is" + lettersToCheck[letterCount]);

                //loop through the grip
                for(int Row = 0; Row <  board.GetLength(0); Row++)
                {
                    for(int Column = 0; Column < board.GetLength(1); Column++)
                    {
                        //if you have a match.
                        if (lettersToCheck[letterCount] == board[Row, Column])
                        {
                            //erase the letter so you can't reuse it.
                            Console.WriteLine("match:   " + board[Row, Column]);
                            board[Row, Column] = '';

                            //need to check if the letters around it are a match
                            result = checkNextLetter(Row, Column, board, lettersToCheck[letterCount + 1]);
                            Console.WriteLine(result);
                            if(result == false)
                            { 
                                return false;
                            }
                            else
                            {
                                Console.WriteLine("break");
                                break;
                            }
                        }
                        else
                        {
                            result = false;
                        }
                       
                        
                    }
                    if (result == true)
                    { break; }

                }

            }


            return true;
        }  //end function


        public static bool checkNextLetter(int Row, int Column, char[,] board, char nextLetter )
        {

            //working down first
            for (int nextRow = -1; nextRow < 2; nextRow++)
            {
                for (int nextColumn = -1; nextColumn < 2; nextColumn++)
                {
                    if ((Row + nextRow < 0) || (Row + nextRow) > board.GetLength(0) || (Column + nextColumn < 0) || (Column + nextColumn) > board.GetLength(1))
                    {
                        Console.WriteLine("skip it");
                    }
                    else 
                    {

                        if (nextLetter == board[Row + nextRow, Column + nextColumn])
                        {
                            Console.WriteLine(Row + nextRow + " and  " + Column + nextColumn);
                            Console.WriteLine("match");
                            return true;
                        }
                    }
                }

            }
            Console.WriteLine("no match");
            return false;
        }

    }
}
//if(  !(Row + nextRow< 0) && (Row + nextRow > board.GetLength(0)) && (Column + nextColumn< 0) && (Column + nextColumn) > board.GetLength(1))