using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RaceTrack;

class RaceGame
{
    public const char pWrite = '*';
    public const char wallV = '║';
    public const char wallH = '═';

    public static int pX = 80;
    public static int pY = 25;

    public static bool run = true;

    public static string WallsString =
        "╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                ╔════════════════════════════════════════════════════════════════════╗                ║\n" +
        "║                ║                                                                    ║                ║\n" +
        "║                ║                                                                    ║                ║\n" +
        "║                ║                                                                    ║                ║\n" +
        "║                ║                                                                    ║                ║\n" +
        "║                ║                                                                    ║                ║\n" +
        "║                ║                                                                    ║                ║\n" +
        "║                ║                                                                    ║                ║\n" +
        "║                ║                                                                    ║                ║\n" +
        "║                ║                                                                    ║                ║\n" +
        "║                ║                                                                    ║                ║\n" +
        "║                ║                                                                    ║                ║\n" +
        "║                ╚════════════════════════════════════════════════════════════════════╝                ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "║                                                                                                      ║\n" +
        "╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝";


    public static void Run()
    {
        Draw();
    }

    public static void Draw()
    {
        MapDraw();
        while (run)
        {
            Console.CursorVisible = false;
            PlayerDraw(pWrite, pX, pY);
            PlayerMove();
        }
    }

    public static void PlayerDraw(char toWrite, int x, int y)
    {
        try
        {
            if (x >= 0 && y >= 0)
            {
                Console.SetCursorPosition(x, y); // DELETE OLD
                Console.Write(toWrite);

            }
            else
            {
                Die();
            }
        }
        catch (Exception) { }
    }

    public static void MapDraw()
    {
        Console.SetCursorPosition(75, 15);
        Render(WallsString, false);
    }



    public static void Die()
    {
        Console.Clear();
    }


    char BoardAt(int x, int y) => WallsString[y * 42 + x];

    bool IsWall(int x, int y) => BoardAt(x, y) is not ' ';

    //bool CanMove(int x, int y, Direction direction) => direction switch
    //{
    //    Direction.Up =>
    //        !IsWall(x - 1, y - 1) &&
    //        !IsWall(x, y - 1) &&
    //        !IsWall(x + 1, y - 1),
    //    Direction.Down =>
    //        !IsWall(x - 1, y + 1) &&
    //        !IsWall(x, y + 1) &&
    //        !IsWall(x + 1, y + 1),
    //    Direction.Left =>
    //        x - 2 < 0 || !IsWall(x - 2, y),
    //    Direction.Right =>
    //        x + 2 > 40 || !IsWall(x + 2, y),
    //    _ => throw new NotImplementedException(),
    //};

    public static void PlayerMove()
    {

        if (Console.KeyAvailable)
        {
            var command = Console.ReadKey().Key;

            switch (command)
            {
                case ConsoleKey.DownArrow:
                    
                    pY++;
                    break;
                case ConsoleKey.UpArrow:
                    
                    if (pY > 0)
                    {
                        pY--;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    
                    if (pX > 0)
                    {
                        pX--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    
                    pX++;
                    break;
            }


            PlayerDraw(pWrite, pX, pY);
        }

    }


    public static void Render(string @string, bool renderSpace = true)
    {
        int x = Console.CursorLeft;
        int y = Console.CursorTop;
        foreach (char c in @string)
        {
            if (c is '\n')
            {
                Console.SetCursorPosition(x, ++y);
            }
            else if (c is not ' ' || renderSpace)
            {
                Console.Write(c);
            }
            else
            {
                Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
            }
        }
    }
}

