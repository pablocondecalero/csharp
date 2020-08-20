using System;
using System.Threading;

class Pong
{
    static void Main()
    {
        Console.SetWindowSize(80, 25);
        Console.SetBufferSize(80, 25);
        int y1 = 12;
        int y2 = 12;
        int xBall = 20, yBall = 5;
        int xSpeed = 1, ySpeed = 1;
        bool finished = false;
        ConsoleKeyInfo userkey;
        do
        {
            Console.Clear();

            Console.SetCursorPosition(70, y1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("|");

            Console.SetCursorPosition(10, y2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("|");


            Console.SetCursorPosition(xBall, yBall);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("O");

            Console.SetCursorPosition(1, 1);

            if (Console.KeyAvailable)
            {
                userkey = Console.ReadKey(true);
                
                if (userkey.Key == ConsoleKey.UpArrow)
                    y1--;
                if (userkey.Key == ConsoleKey.DownArrow)
                    y1++;
                    
                if (userkey.Key == ConsoleKey.A)
                    y2--;
                if (userkey.Key == ConsoleKey.Z)
                    y2++;    

                if (userkey.Key == ConsoleKey.Escape)
                    finished = true;
            }

            xBall += xSpeed;
            yBall += ySpeed;
            if ((xBall <= 2) || (xBall >= 78))
                xSpeed = -xSpeed;
            if ((yBall <= 2) || (yBall >= 23))
                ySpeed = -ySpeed;

            Thread.Sleep(100);
        }
        while ( ! finished );

        Console.ForegroundColor = ConsoleColor.White;
    }
}
