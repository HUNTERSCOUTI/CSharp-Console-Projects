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

    static int currentTrack = 0;

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
            if (moveOffGoal)
            {
                TrackDraw();
                moveOffGoal = false;
                onRace = true;
            }
        }
        AfterGameScreen();
    }

    static char BoardAt(int x, int y) => LevelSelector()[y * 108 + x];

    static bool IsWall(int x, int y) => BoardAt(x, y) is not ' ' and not '|';

    static bool OnGoal(int x, int y) => BoardAt(x, y) is '|';

    static bool CanMove(int x, int y) => !IsWall(x, y);

    public static (int Left, int Top) GetCursorPosition() => (pX, pY);

    static bool IsGoingTheWrongWay(int x, int y)
    {
        if(BoardAt(x, y) is '|' && x - 1 == 54)
        {
            return true;
        }
        return false;
    }

    static string LevelSelector()
    {
        string[] Levels = new string[] { Track1, Track2 };

        return Levels[currentTrack];
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

            if (IsGoingTheWrongWay(newX, newY)) // Not working yet
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

            if(GetCursorPosition() == (36, 11)) // Play again
            {
                pX = 54;
                pY = 5;
                run = true;
                Run();
            } 
            else if (GetCursorPosition() == (50, 11)) // Exit
            {

            }
        }
    }
}