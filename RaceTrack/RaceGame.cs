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
    public static int pY = 5;

    public static bool run = true;

    public static string WallsString =
        "╔═════════════════════════════════════════════════════════════════════════════════════════════════════════╗\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                  ╔═══════════════════════════════════════════════════════════════════╗                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ╚═══════════════════════════════════════════════════════════════════╝                  ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "╚═════════════════════════════════════════════════════════════════════════════════════════════════════════╝";
    
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
        Console.SetCursorPosition(x, y); // DELETE OLD
        Console.Write(toWrite);
    }

    public static void MapDraw()
    {
        Console.SetCursorPosition(0, 0);
        Render(WallsString, false);
    }

    static char BoardAt(int x, int y) => WallsString[y * 108 + x];
    static bool IsWall(int x, int y) => BoardAt(x, y) is not ' ' and not '|';
    static bool CanMove(int x, int y) => !IsWall(x, y);

    public static void PlayerMove()
    {

        if (Console.KeyAvailable)
        {
            var input = Console.ReadKey().Key;

            var newX = pX;
            var newY = pY;

            switch (input)
            {
                case ConsoleKey.DownArrow:
                    ClearOldPos(pX, pY);
                    newY++;
                    break;
                case ConsoleKey.UpArrow:
                    ClearOldPos(pX, pY);
                    newY--;
                    break;
                case ConsoleKey.LeftArrow:
                    ClearOldPos(pX, pY);
                    newX--;
                    break;
                case ConsoleKey.RightArrow:
                    ClearOldPos(pX, pY);
                    newX++;
                    break;
            }
            if(CanMove(newX, newY))
            {
                pX = newX;
                pY = newY;
            }else
            {
                run = false;
                Die();
            }
        }
    }

    public static void Die()
    {
        Console.Clear();
    }

    public static void ClearOldPos(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(" ");
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
            else if (c is not ' ' || c is not '|' || renderSpace)
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