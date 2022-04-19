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

    public static int[] PlaceX = new int[] { 26, 52, 78, 104, 130, 156};
    public static int[] PlaceY = new int[] { 9, 16, 23, 30, 37, 44};
    

    public static int x = 0;
    public static int y = 0;

    public static void Main()
    {
        Console.Title = "Tents";
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        ShowWindow(ThisConsole, MAXIMIZE);

        bool game = true;
        DrawBoard();
        Console.SetCursorPosition(PlaceX[x], PlaceY[y]);
        while (game)
        {
            PlyMove();
        }
    }

    public static void PlyMove()
    {

        bool[] tents = new bool[36]; // Not finished

        if (Console.KeyAvailable)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if (PlaceY[y] != 9)
                    {
                        y -= 1;
                        Console.SetCursorPosition(PlaceX[x], PlaceY[y]);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (PlaceY[y] != 44)
                    {
                        y += 1;
                        Console.SetCursorPosition(PlaceX[x], PlaceY[y]);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if(PlaceX[x] != 26)
                    {
                        x -= 1;
                        Console.SetCursorPosition(PlaceX[x], PlaceY[y]);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (PlaceX[x] != 156)
                    {
                        x += 1;
                        Console.SetCursorPosition(PlaceX[x], PlaceY[y]);
                    }
                    break;
                case ConsoleKey.X:
                    Console.SetCursorPosition(PlaceX[x], PlaceY[y]);
                    Console.Write("X");
                    break;
                case ConsoleKey.Backspace:
                    Console.Write("");
                    break;
                default:
                    break;
            }
        }
    }

    public static void DrawBoard()
    {
        #region Edges
        //Top and Bottom
        Console.SetCursorPosition(13, 5);
        for(int i = 0; i < 157; i++)
        {
            Console.Write("*");
        }
        Console.SetCursorPosition(13, 49);
        for (int i = 0; i < 157; i++)
        {
            Console.Write("*");
        }

        //Sides
        for (int j = 6; j < 49; j++)
        {
            Console.SetCursorPosition(169, j);
            Console.Write("|");
        }
        for (int j = 6; j < 49; j++)
        {
            Console.SetCursorPosition(13, j);
            Console.Write("|");
        }
        #endregion
    }   
}