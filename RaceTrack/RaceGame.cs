using System;
using System.Diagnostics;

namespace RaceTrack;


public partial class RaceGame
{
    static bool run = true;
    static bool playAgain = true;
    static bool trackComplete = false;
    static bool completedAllTracks = false;

    static int playerX = 54;
    static int playerY = 5;

    static int currentTrack = 1;

    static Stopwatch timer = new Stopwatch();
    public static TimeSpan pb;

    public static void Run()
    {
        while (playAgain)
        {
            run = true;
            currentTrack = 0; //TBC
            timer.Reset();

            SetPlayerPosPerTrack();
            TrackDraw();

            Console.CursorVisible = false;

            while (run && !completedAllTracks)
            {
                TimeWrite();
                PlayerWrite();
                PlayerMove();
                if (trackComplete)
                {
                    NextTrack();
                }
            }
            TimeComplete();
            TimeWrite();
            AfterGameScreen();
        }
    }

    static char BoardAt(int x, int y) => Levels[currentTrack][y][x];

    static bool IsWall(int x, int y) => BoardAt(x, y) is not ' ' and not '|' and not '#';

    static bool OnGoal(int x, int y) => BoardAt(x, y) is '|';

    static bool CanMove(int x, int y) => !IsWall(x, y);

    public static (int Left, int Top) GetCursorPosition() => (playerX, playerY);

    static void TimeComplete()
    {
        timer.Stop();
        TimeSpan timeTaken = timer.Elapsed;

        if (timeTaken < pb)
            pb = timeTaken;
    }

    static void SetPlayerPosPerTrack()
    {
        for (int r = 0; r < Levels[currentTrack].Length; r++)
        {
            for (int c = 0; c < Levels[currentTrack][r].Length; c++)
            {
                if (Levels[currentTrack][r][c] is '#')
                {
                    playerX = c;
                    playerY = r;
                }
            }
        }
    }

    static void NextTrack() //FIX
    {
        bool finalTrack = false;
        if (currentTrack == Levels.Length)
            finalTrack = true;
        if (finalTrack) {
            currentTrack++;
            trackComplete = false;
            Console.Clear();
            SetPlayerPosPerTrack();
            TrackDraw();
        }
    }

    static void PlayerMove()
    {
        var newX = playerX;
        var newY = playerY;

        if (Console.KeyAvailable)
        {
            var input = Console.ReadKey().Key;

            switch (input)
            {
                case ConsoleKey.DownArrow:
                    ClearOldPos(playerX, playerY);
                    newY++;
                    break;
                case ConsoleKey.UpArrow:
                    ClearOldPos(playerX, playerY);
                    newY--;
                    break;
                case ConsoleKey.LeftArrow:
                    ClearOldPos(playerX, playerY);
                    newX--;
                    break;
                case ConsoleKey.RightArrow:
                    ClearOldPos(playerX, playerY);
                    newX++;
                    break;
                default:
                    ClearOldPos(playerX+1, playerY);
                    break;
            }

            if (run)
            {
                PlayerCalcRace(newX, newY);
            }
            else
            {
                PlayerCalcMenu(newX, newY);
            }
        }
    }
    static void PlayerCalcRace(int newX, int newY)
    {
        for (int r = 0; r < Levels[currentTrack].Length; r++)
        {
            for (int c = 0; c < Levels[currentTrack][r].Length; c++)
            {
                if ((newX, newY) != (c, r) && Levels[currentTrack][r][c] is '|' or '#')
                {
                    Console.SetCursorPosition(c, r);
                    Console.Write('|');
                }
            }
        }

        if (!timer.IsRunning && (playerX, playerY) != (newX, newY))
        {
            timer.Start();
        }

        if (playerX > newX && OnGoal(newX, newY))
            return;

        if (playerX < newX && OnGoal(newX, newY))
            trackComplete = true;
        

        //Checks if player is in wall, if so die
        if (CanMove(newX, newY))
        {
            playerX = newX;
            playerY = newY;
        }
        else
        {
            run = false;
        }
    }

    static void PlayerCalcMenu(int newX, int newY)
    {
        playerX = newX;
        playerY = newY;

        if (GetCursorPosition() == (36, 11)) // Play again
        {
            playerDecide = false;
        }
        else if (GetCursorPosition() == (50, 11)) // Exit
        {
            Console.Clear();
            playAgain = false;
            playerDecide = false;
        }
    }
}