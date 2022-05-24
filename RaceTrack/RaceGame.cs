using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Timers;

namespace RaceTrack;


public partial class RaceGame
{
    static bool run = true;
    static bool onRace = false;
    static bool isStart = true;
    static bool moveOffGoal = false;

    static int pX = 54;
    static int pY = 5;

    static Stopwatch timer = new Stopwatch();
    public static TimeSpan pb;
    static TimeSpan endTime;

    public static void Run()
    {
        if(isStart)
            TrackDraw();
        Console.CursorVisible = false;
        while (run)
        {
            TimeWrite();
            PlayerWrite();
            PlayerMove();
            Console.Write(pX);
            if (moveOffGoal)
            {
                TrackDraw();
                moveOffGoal = false;
                onRace = true;
            }
        }
        AfterGameScreen();
    }

    static char BoardAt(int x, int y) => Track1[y * 108 + x];

    static bool IsWall(int x, int y) => BoardAt(x, y) is not ' ' and not '|';

    static bool OnGoal(int x, int y) => BoardAt(x, y) is '|';

    static bool CanMove(int x, int y) => !IsWall(x, y);

    static bool IsGoingTheWrongWay(int x, int y)
    {
        if(BoardAt(x, y) is '|' && x - 1 == 54)
        {
            return true;
        }
        return false;
    }

    static string TimeCalc(string _time) //Calculates the times when starting and when ended
    {
        TimeSpan timeTaken = timer.Elapsed;
        if (onRace == true)
        {
            timer = new Stopwatch();
            timer.Start();
            onRace = false; isStart = false;
        } else
        {
            if (OnGoal(pX, pY))
            {
                timer.Stop();
                endTime = timeTaken;
                if(endTime > pb)
                    pb = endTime;
                if (!isStart)
                {
                    run = false;
                }
                return "00.000";
            }
        }

        _time = timeTaken.ToString(@"ss\.fff");

        return _time;
    }

    static void PlayerMove()
    {
        var newX = pX;
        var newY = pY;

        if (Console.KeyAvailable)
        {
            var input = Console.ReadKey().Key;


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
                default:
                    ClearOldPos(pX+1, pY);
                    break;
            }

            PlayerCalc(newX, newY);
        }
    }
    static void PlayerCalc(int newX, int newY)
    {
        //Checks if player is moving off goal
        if (run)
        {
            if (OnGoal(pX, pY) && BoardAt(newX, newY) == ' ')
            {
                moveOffGoal = true;
            }
            else
            {
                moveOffGoal = false;
            }

            if (IsGoingTheWrongWay(newX, newY))
            {
                Console.Clear();
                Console.Write("wrong way");
                run = false;
            }
            //Checks if player is in wall, if so die
            if (CanMove(newX, newY))
            {
                pX = newX;
                pY = newY;
            }
            else
            {
                run = false;
                Die();
            }
        } else
        {
            pX = newX;
            pY = newY;
        }
        
    }

    static void PlayerDraw(char toWrite, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(toWrite);
    }

    static void TrackDraw()
    {
        Console.SetCursorPosition(0, 0);
        Render(Track1, false);
    }

    static void Render(string @string, bool renderSpace = true)
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