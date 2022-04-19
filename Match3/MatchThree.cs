#region System
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
    public static int[,] NumBoard = new int[11, 6];
    public static int YNumPos = 45;
    public static int Guess = 1;

    public static int Points = 0;
    public static bool Game = true;

    public static int[] PlaceX = new int[] { 26, 52, 78, 104, 130, 156 };
    public static int[] PlaceY = new int[] { 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };

    public static void Main()
    {
        Console.Title = "Match 3";
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        ShowWindow(ThisConsole, MAXIMIZE);


        DrawNums();
        DrawBoard();
        Console.SetCursorPosition(XNumPos[0], YNumPos);
        while (Game)
        {
            PlyMove();
            CurrentPlace();
        }
    }

    public static void PlyMove()
    {
        int[] plyNums = new int[3];
         

        while (Console.KeyAvailable && Guess != 4)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    plyNums[Guess - 1] = NumBoard[10, 0];
                    Console.SetCursorPosition(PlaceX[0], PlaceY[10]);
                    Console.Write(" ");
                    Console.SetCursorPosition(XNumPos[Guess - 1], YNumPos);
                    Console.Write(NumBoard[10, 0]);
                    Guess++;
                    break;
                case ConsoleKey.D2:
                    plyNums[Guess - 1] = NumBoard[10, 1];
                    Console.SetCursorPosition(XNumPos[Guess - 1], YNumPos);
                    Console.Write(NumBoard[10, 1]);
                    Guess++;
                    break;
                case ConsoleKey.D3:
                    plyNums[Guess - 1] = NumBoard[10, 2];
                    Console.SetCursorPosition(XNumPos[Guess - 1], YNumPos);
                    Console.Write(NumBoard[10, 2]);
                    Guess++;
                    break;
                case ConsoleKey.D4:
                    plyNums[Guess - 1] = NumBoard[10, 3];
                    Console.SetCursorPosition(XNumPos[Guess - 1], YNumPos);
                    Console.Write(NumBoard[10, 3]);
                    Guess++;
                    break;
                case ConsoleKey.D5:
                    plyNums[Guess - 1] = NumBoard[10, 4];
                    Console.SetCursorPosition(XNumPos[Guess - 1], YNumPos);
                    Console.Write(NumBoard[10, 4]);
                    Guess++;
                    break;
                case ConsoleKey.D6:
                    plyNums[Guess - 1] = NumBoard[10, 5];
                    Console.SetCursorPosition(XNumPos[Guess - 1], YNumPos);
                    Console.Write(NumBoard[10, 5]);
                    Guess++;
                    break;
                default:
                    break;
            }
        }
        if (Guess == 4)
        {
            CheckNums(plyNums[0], plyNums[1], plyNums[2]);
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
                NumBoard[y, j] = rng.Next(1, 4);
                Console.SetCursorPosition(PlaceX[j], PlaceY[y]);
                Console.Write(NumBoard[y, j]);
            }
            y++;
            if (y == PlaceY.Length) y = 0;
        }
    }

    public static void CurrentPlace()
    {
        if (Guess == 1)
        {
            Console.SetCursorPosition(XNumPos[0], YNumPos);
        }
        else if (Guess == 2)
        {
            Console.SetCursorPosition(XNumPos[1], YNumPos);
        }
        else if (Guess == 3)
        {
            Console.SetCursorPosition(XNumPos[2], YNumPos);
        }
    }

    public static void CheckNums(int num1, int num2, int num3)
    {
        if (num1 == num2 && num2 == num3)
        {
            Points++;
        }
        else
        {
            Console.SetCursorPosition(90, 43);
            Console.Write("Wrong");
        }
        Thread.Sleep(2000);
        for (int i = 0; i < XNumPos.Length; i++)
        {
            Console.SetCursorPosition(XNumPos[i], YNumPos);
            Console.Write(" ");
        }
        XNum = 1;
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
        Console.SetCursorPosition(83, YNumPos - 1);
        Console.Write("*******************");
        Console.SetCursorPosition(83, YNumPos);
        Console.Write("|     |     |     |");
        Console.SetCursorPosition(83, YNumPos + 1);
        Console.Write("*******************");
        #endregion

        #region Bottom Numbers
        int botNums = 1;
        for (int i = 0; i < PlaceX.Length; i++)
        {
            Console.SetCursorPosition(PlaceX[i] - 1, 42);
            Console.Write("[" + botNums + "]");
            botNums++;
        }
        #endregion
    }
}