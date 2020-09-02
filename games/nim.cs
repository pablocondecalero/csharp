//Pablo Conde - August 2020
/*THE NIM GAME: take any number of pieces from the same row (at least one)
  The player who leaves the last piece wins the game */

using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;

class Nim
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(50, 3);
        Console.WriteLine("THE NIM GAME");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 5);
        Random random = new Random();
        string player1, player2, player;
        
        bool anotherGame = true;
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        
        do
        {
            List<int> pieces = new List<int>();
            Console.Write("Do you want to start? (y/n): ");
            string start = Console.ReadLine();
            
            if(start.ToLower() == "y")
            {
                player1 = name;        
                player2 = "Computer";
            }
            
            else
            {
                player1 = "Computer";
                player2 = name;
            }
       
                
            for (int i = 0; i < 3; i++)
                pieces.Add(random.Next(1, 7));
            pieces.Sort();
            
            DrawPieces(pieces);
            
            bool enoughPieces = true;
            int turn = 1;
            int total = 0;
    
            do
            {
                total = 0;
                if(turn % 2 != 0)
                    player = player1;
                else
                    player = player2;

                Console.WriteLine(player + "'s turn: ");
                
                bool correct = false;
                do
                {
                    string[] couple;
                    Console.Write("Enter row and pieces: ");
                    if(player == "Computer")
                    {
                        System.Threading.Thread.Sleep(1200);
                        Console.WriteLine(MachineMove(pieces));
                        couple = MachineMove(pieces).Split();    
                    }
                        
                    else
                        couple = Console.ReadLine().Split();
                        
                    if(IsNumber(couple[0]) &&
                        IsNumber(couple[0]))
                    {
                        if(Convert.ToInt32(couple[0]) > 0 &&
                           Convert.ToInt32(couple[0]) <= pieces.Count)
                        {   
                            if(Convert.ToInt32(couple[1]) > 0 &&
                                Convert.ToInt32(couple[1]) <= 
                                pieces[Convert.ToInt32(couple[0]) - 1])
                            { 
                                int rowNumber = Convert.ToInt32(couple[0]) - 1;
                                int piecesNumber = Convert.ToInt32(couple[1]);
                                pieces[rowNumber] -= piecesNumber;

                                DrawPieces(pieces);
                                turn++;

                                for (int i = 0; i < pieces.Count; i++)
                                    total += pieces[i];
                                    
                                if (total < 2)
                                    enoughPieces = false;
                                correct = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine();

                                Console.WriteLine("Please, choose " 
                                + " a valid number of pieces"); 
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine();

                            Console.WriteLine("Please, choose a valid row"); 
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine("Only natural numbers are allowed");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                while(!correct);
            }
            while(enoughPieces);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(player + " wins!!");
            Console.ForegroundColor = ConsoleColor.White;
            
            Console.Write("Play again (y/n)? ");
            string again = Console.ReadLine();
            Console.WriteLine();
            
            if(again.ToLower() != "y")
                anotherGame = false;
        }
        while(anotherGame);
        
        Console.WriteLine("See you soon!");
        
    }
    
    static void DrawPieces (List<int> pieces)
    {
        Console.WriteLine();
        for (int i = 0; i < pieces.Count; i++)
        {
            Console.Write("Row " + (i + 1) + " => ");
            
            for (int j = 0; j < pieces[i]; j++)
            {
                Console.Write("o ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    
    static string MachineMove(List<int> pieces)
    {
        string couple = "";
        int activeRows = 0;
        int rowNum = 0;
        int piecesNum = 0;
        
        for (int i = 0; i < pieces.Count; i++)
        {
            if(pieces[i] > 0)
                activeRows++;
        }
        
        switch(activeRows)
        {
            case 1:
                for (int i = 0; i < pieces.Count; i++)
                {
                    if(pieces[i] > 1)
                        rowNum = i + 1;
                }
                
                piecesNum = pieces[rowNum - 1] - 1;
                
                break;
                
            case 2:
      
                List<int> values = new List<int>();
                for (int i = 0; i < pieces.Count; i++)
                {
                    if(pieces[i] > 0)
                    {
                        values.Add(i);
                        values.Add(pieces[i]);
                    }
                }
                
                if(values[1] > values[3])
                {
                    rowNum = values[0] + 1;
                    
                    if(values[3] == 1)
                        piecesNum = values[1];
                    else
                        piecesNum = values[1] - values[3];
                }
                
                else if (values[1] < values[3])
                {
                    rowNum = values[2] + 1;
                    
                    if(values[1] == 1)
                        piecesNum = values[3];
                    
                    else
                        piecesNum = values[3] - values[1];
                }
                
                else
                {
                    rowNum = values[0] + 1;
                    piecesNum = 1;
                }    
                break;
            
            case 3:
                if(pieces[0] == pieces[1] && pieces[1] == pieces[2]
                    && pieces[0] == 1)
                {
                    rowNum = 0 + 1;
                    piecesNum = 1;
                }
                
                else if(pieces[0] == pieces[1])
                {
                    if(pieces[0] == 1)
                    {
                        rowNum = 2 + 1;
                        piecesNum = pieces[2] - 1;
                    }
                    else
                    {
                        rowNum = 2 + 1;
                        piecesNum = pieces[2];
                    }
                  
                }
                
                else if (pieces[0] == pieces[2])
                {
                    if(pieces[0] == 1)
                    {
                        rowNum = 1 + 1;
                        piecesNum = pieces[1] - 1;
                    }
                    else
                    {
                        rowNum = 1 + 1;
                        piecesNum = pieces[1];
                    }
                    
                }
                    
                else if(pieces[1] == pieces[2])
                {
                    if(pieces[1] == 1)
                    {
                        rowNum = 0 + 1;
                        piecesNum = pieces[0] - 1;
                    }
                    else
                    {
                        rowNum = 0 + 1;
                        piecesNum = pieces[0];
                    }
                }
                
                else //The 3 rows are different
                {
                    string[] twoValues = ThreeDifRows(pieces).Split();
                    rowNum = Convert.ToInt32(twoValues[0]);
                    piecesNum = Convert.ToInt32(twoValues[1]);
                }
                break;
        }
        
        couple = rowNum + " " + piecesNum;
        
        return couple;
    }
    
    static string ThreeDifRows (List<int> pieces)
    {
        string couple;
        int rowNum = 0;
        int piecesNum = 0;
        int totalZero = 0;
        int powerOfTwo = 1;
        bool loops = true;
        List<int> auxList = new List<int>();
        
        //New list           
        for (int i = 0; i < pieces.Count; i++)
            auxList.Add(pieces[i]);
            
        int maxList = auxList.Max();
        while(maxList > 1)
        {
            maxList /= 2;
            powerOfTwo *= 2;
        }

       //taking powerOfTwo
        while(loops)
        {
            if(powerOfTwo == 1)
                loops = false;
                
            if(auxList[0] > powerOfTwo - 1 && auxList[1] >  powerOfTwo - 1)
            {
                auxList[0] -= powerOfTwo;
                auxList[1] -= powerOfTwo;
            }
            else if(auxList[0] > powerOfTwo - 1 && auxList[2] > powerOfTwo - 1)
            {
                auxList[0] -= powerOfTwo;
                auxList[2] -= powerOfTwo;
            }
            else if(auxList[1] > powerOfTwo - 1 && auxList[2] >  powerOfTwo - 1)
            {
                auxList[1] -= powerOfTwo;
                auxList[2] -= powerOfTwo;
            }
            else
                powerOfTwo /= 2;
        }
          
        for (int i = 0; i < auxList.Count; i++)
            totalZero += auxList[i];
 
        
        if (totalZero > 0)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if(auxList[i] > 0)
                {
                    rowNum = i + 1;
                    piecesNum = auxList[i];
                }
            }
        }
        else
        {
            Random random = new Random();
            rowNum = random.Next(1, 3); 
            piecesNum = 1;
        }

        couple = rowNum + " " + piecesNum;
        return couple;
    }
    
    static bool IsNumber(string num)
    {
        if (Regex.IsMatch(num, @"^\d+$"))
            return true;
        else
            return false;
    }
}
