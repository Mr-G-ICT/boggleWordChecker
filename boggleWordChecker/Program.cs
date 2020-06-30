using System;
using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;
using System.Threading;

namespace boggleWordChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] boggleGrid = {new[] {'E','A','R','A'},
         new[] {'N','L','E','C'},
          new[] {'I','A','I','S'},
         new[] {'B','Y','O','R'} };

        Console.WriteLine("Hello World!");
            Console.WriteLine(boggleWordChecker(boggleGrid, "EARS"));
        }

   

        public static bool boggleWordChecker(char[][] board, string word)
        {
            //split the string
            //find the first letter
            //check letters around it
            //if they match, move on one letter.
           

            char[] lettersToCheck = word.ToCharArray();
            int numColumns = getColumnLength(board, 0);
            int numRows = board[0].Length;

            Console.WriteLine(numColumns + "num columns");
            Console.WriteLine(numRows + " num rows");

            bool result = false;

            for (int letterCount = 0; letterCount < lettersToCheck.Length -1; letterCount++)
            {
                Console.WriteLine("letter is" + lettersToCheck[letterCount]);

                //loop through the grip
                for(int Row = 0; Row <  numRows; Row++)
                {
                    for(int Column = 1; Column < numColumns; Column++)
                    {
                        //if you have a match.
                        if (lettersToCheck[letterCount] == board[Row][Column])
                        {
                            //erase the letter so you can't reuse it.
                            Console.WriteLine("match:   " + board[Row][ Column]);
                            board[Row][Column] = '*';

                            //need to check if the letters around it are a match
                            result = checkNextLetter(Row, Column, board, lettersToCheck[letterCount + 1], numRows, numColumns);
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

        public static int getColumnLength(char[][] arrays, int columnNumber)
        {
            int count = 0;
            for (int i = 0; i < arrays.Length; i++)
            {
                if (arrays[1].Length > columnNumber)
                {
                    count++;
                }
            }
            return count;
        }


        public static bool checkNextLetter(int Row, int Column, char[][] board, char nextLetter, int numRows, int numColumns )
        {
            // as this is a 2D JAgged array, i'm sending the num rows and columns as these are pre-calculated

            //working down first
            for (int nextRow = -1; nextRow < 2; nextRow++)
            {
                for (int nextColumn = -1; nextColumn < 2; nextColumn++)
                {
                    if ((Row + nextRow < 0) || (Row + nextRow) > numRows || (Column + nextColumn < 0) || (Column + nextColumn) > numColumns)
                    {
                        Console.WriteLine("skip it");
                    }
                    else 
                    {

                        if (nextLetter == board[Row + nextRow][ Column + nextColumn])
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