using System;
using System.Diagnostics;

namespace RaceGame;


public class RaceGame
{
    private readonly Draw _draw;
    public Tracks Tracks { get; } = new Tracks();

    private bool _run = true;
    private bool _playAgain = true;
    private bool _trackComplete = false;
    private const bool CompletedAllTracks = false;
    private bool _finalTrack = false;

    public int playerX = 54;
    public int playerY = 5;

    public int currentTrack = 1;

    public Stopwatch timer = new();
    public TimeSpan pb;
    public RaceGame()
    {
        _draw = new Draw(this);
    }

    public void Run()
    {
        while (_playAgain)
        {
            _run = true;
            currentTrack = 1; //TBC
            timer.Reset();

            SetPlayerPosPerTrack();

            _draw.TrackDraw();

            Console.CursorVisible = false;

            while (_run && !CompletedAllTracks)
            {
                _draw.TimeWrite();
                _draw.PlayerWrite();
                PlayerMove();
                NextTrack();
            }
            TimeComplete();
            _draw.TimeWrite();
            _draw.AfterGameScreen();
        }
    }

    public char BoardAt(int x, int y) => Tracks.levels[currentTrack][y][x];

    public bool IsWall(int x, int y) => BoardAt(x, y) is not ' ' and not '|' and not '#';

    public bool OnGoal(int x, int y) => BoardAt(x, y) is '|' or '#';

    public bool CanMove(int x, int y) => !IsWall(x, y);

    public (int Left, int Top) GetCursorPosition() => (playerX, playerY);

    public void TimeComplete()
    {
        timer.Stop();
        var timeTaken = timer.Elapsed;

        if (timeTaken < pb)
            pb = timeTaken;
    }

    public void SetPlayerPosPerTrack()
    {
        var level = Tracks.levels;

        for (var r = 0; r < level[currentTrack].Length; r++)
        {
            for (var c = 0; c < level[currentTrack][r].Length; c++)
            {
                if (level[currentTrack][r][c] is '#')
                {
                    playerX = c;
                    playerY = r;
                }
            }
        }
    }

    public void NextTrack()
    {
        if (_trackComplete)
        {
            if (currentTrack == Tracks.levels.Length)
                _finalTrack = true;
            if (!_finalTrack)
            {
                currentTrack++;
                _trackComplete = false;
                Console.Clear();
                SetPlayerPosPerTrack();
                _draw.TrackDraw();
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
                    _draw.ClearOldPos(playerX, playerY);
                    newY++;
                    break;
                case ConsoleKey.UpArrow:
                    _draw.ClearOldPos(playerX, playerY);
                    newY--;
                    break;
                case ConsoleKey.LeftArrow:
                    _draw.ClearOldPos(playerX, playerY);
                    newX--;
                    break;
                case ConsoleKey.RightArrow:
                    _draw.ClearOldPos(playerX, playerY);
                    newX++;
                    break;
                default:
                    _draw.ClearOldPos(playerX+1, playerY);
                    break;
            }

            if (_run)
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
        var level = Tracks.levels;

        for (var r = 0; r < level[currentTrack].Length; r++)
        {
            for (var c = 0; c < level[currentTrack][r].Length; c++)
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
            _trackComplete = true;


        //Checks if player is in wall, if so die
        if (CanMove(newX, newY))
        {
            playerX = newX;
            playerY = newY;
        }
        else
        {
            _run = false;
        }
    }

    public void PlayerCalcMenu(int newX, int newY)
    {
        playerX = newX;
        playerY = newY;

        if (GetCursorPosition() == (36, 11)) // Play again
        {
            _draw.playerDecide = false;
        }
        else if (GetCursorPosition() == (50, 11)) // Exit
        {
            Console.Clear();
            _playAgain = false;
            _draw.playerDecide = false;
        }
    }
}