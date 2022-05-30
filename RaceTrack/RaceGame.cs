using System;
using System.Diagnostics;

namespace RaceGame;


public class RaceGame
{
    readonly Draw draw;
    public Tracks Tracks { get; } = new Tracks();

    bool run = true;
    bool playAgain = true;
    bool trackComplete = false;
    readonly bool completedAllTracks = false;
    bool finalTrack = false;

    public int playerX = 54;
    public int playerY = 5;

    public int currentTrack = 1;

    public Stopwatch timer = new Stopwatch();
    public TimeSpan pb;
    public RaceGame()
    {
        draw = new Draw(this);
    }

    public void Run()
    {
        while (playAgain)
        {
            run = true;
            currentTrack = 1; //TBC
            timer.Reset();

            SetPlayerPosPerTrack();

            draw.TrackDraw();

            Console.CursorVisible = false;

            while (run && !completedAllTracks)
            {
                draw.TimeWrite();
                draw.PlayerWrite();
                PlayerMove();
                NextTrack();
            }
            TimeComplete();
            draw.TimeWrite();
            draw.AfterGameScreen();
        }
    }

    public char BoardAt(int x, int y) => Tracks.Levels[currentTrack][y][x];

    public bool IsWall(int x, int y) => BoardAt(x, y) is not ' ' and not '|' and not '#';

    public bool OnGoal(int x, int y) => BoardAt(x, y) is '|' or '#';

    public bool CanMove(int x, int y) => !IsWall(x, y);

    public (int Left, int Top) GetCursorPosition() => (playerX, playerY);

    public void TimeComplete()
    {
        timer.Stop();
        TimeSpan timeTaken = timer.Elapsed;

        if (timeTaken < pb)
            pb = timeTaken;
    }

    public void SetPlayerPosPerTrack()
    {
        var level = Tracks.Levels;

        for (int r = 0; r < level[currentTrack].Length; r++)
        {
            for (int c = 0; c < level[currentTrack][r].Length; c++)
            {
                if (level[currentTrack][r][c] is '#')
                {
                    playerX = c;
                    playerY = r;
                }
            }
        }
    }

    public void NextTrack() //FIX
    {

        if (trackComplete)
        {
            if (currentTrack == Tracks.Levels.Length)
                finalTrack = true;
            if (!finalTrack)
            {
                currentTrack++;
                trackComplete = false;
                Console.Clear();
                SetPlayerPosPerTrack();
                draw.TrackDraw();
            }
        }
    }

    public void PlayerMove()
    {
        var newX = playerX;
        var newY = playerY;

        if (Console.KeyAvailable)
        {
            var input = Console.ReadKey().Key;

            switch (input)
            {
                case ConsoleKey.DownArrow:
                    draw.ClearOldPos(playerX, playerY);
                    newY++;
                    break;
                case ConsoleKey.UpArrow:
                    draw.ClearOldPos(playerX, playerY);
                    newY--;
                    break;
                case ConsoleKey.LeftArrow:
                    draw.ClearOldPos(playerX, playerY);
                    newX--;
                    break;
                case ConsoleKey.RightArrow:
                    draw.ClearOldPos(playerX, playerY);
                    newX++;
                    break;
                default:
                    draw.ClearOldPos(playerX+1, playerY);
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
    public void PlayerCalcRace(int newX, int newY)
    {
        var level = Tracks.Levels;

        for (int r = 0; r < level[currentTrack].Length; r++)
        {
            for (int c = 0; c < level[currentTrack][r].Length; c++)
            {
                if ((newX, newY) != (c, r) && level[currentTrack][r][c] is '|' or '#')
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

    public void PlayerCalcMenu(int newX, int newY)
    {
        playerX = newX;
        playerY = newY;

        if (GetCursorPosition() == (36, 11)) // Play again
        {
            draw.playerDecide = false;
        }
        else if (GetCursorPosition() == (50, 11)) // Exit
        {
            Console.Clear();
            playAgain = false;
            draw.playerDecide = false;
        }
    }
}