#region System
using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
#endregion

class main
{
    #region Fullscreen Variables

    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();
    private static IntPtr ThisConsole = GetConsoleWindow();
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private const int HIDE = 0;
    private const int MAXIMIZE = 3;
    private const int MINIMIZE = 6;
    private const int RESTORE = 9;
    #endregion

    public static int[] XNumPos = new int[] { 86, 92, 98 };
    public static int YNumPos = 45;
    public static int XNum = 1;

    public static int[] PlaceX = new int[] { 26, 52, 78, 104, 130, 156 };
    public static int[] PlaceY = new int[] { 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };

    public static void Main()
    {
        Console.Title = "Match 3";
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        ShowWindow(ThisConsole, MAXIMIZE);

        bool game = true;
        DrawNums();
        DrawBoard();
        Console.SetCursorPosition(XNumPos[0], YNumPos);
        while (game)
        {
            PlyMove();
        }
    }

    public static void PlyMove()
    {
        if (Console.KeyAvailable)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    
                    break;
                case ConsoleKey.D2:

                    break;
                case ConsoleKey.D3:

                    break;
                case ConsoleKey.D4:

                    break;
                case ConsoleKey.D5:

                    break;
                case ConsoleKey.D6:
                    
                    break;
                default:
                    break;
            }
        }
    }

    public static void DrawNums()
    {
        Random rng = new Random();
        int y = 0;

        for (int i = 0; i < 36; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                int bottomNums = rng.Next(1, 4);
                //Add number to posistion in 2D array
                Console.SetCursorPosition(PlaceX[j], PlaceY[y]);
                Console.Write(bottomNums);
            }
            //Put it into the 2D array
            y++;
            if (y == PlaceY.Length) y = 0;
        }
    }

    public static void DrawBoard()
    {
        #region Edges
        //Top and Bottom
        Console.SetCursorPosition(13, 2);
        for (int i = 0; i < 157; i++)
        {
            Console.Write("*");
        }
        Console.SetCursorPosition(13, 49);
        for (int i = 0; i < 157; i++)
        {
            Console.Write("*");
        }

        //Sides
        for (int j = 3; j < 49; j++)
        {
            Console.SetCursorPosition(169, j);
            Console.Write("|");
        }
        for (int j = 3; j < 49; j++)
        {
            Console.SetCursorPosition(13, j);
            Console.Write("|");
        }
        #endregion

        #region Bottom Box
        Console.SetCursorPosition(83, YNumPos-1);
        Console.Write("*******************");
        Console.SetCursorPosition(83, YNumPos);
        Console.Write("|     |     |     |");
        Console.SetCursorPosition(83, YNumPos+1);
        Console.Write("*******************");
        #endregion

        #region Bottom Numbers
        int botNums = 1;
        for (int i = 0; i < PlaceX.Length; i++)
        {
            Console.SetCursorPosition(PlaceX[i]-1, 42);
            Console.Write("[" + botNums + "]");
            botNums++;
        }
        #endregion

    }
}