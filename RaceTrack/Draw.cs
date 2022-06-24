using System;

namespace RaceGame;

public class Draw
{
    private readonly RaceGame _logic;
    private readonly Tracks _tracks;

    public const char PWrite = '*';

    public bool playerDecide = true;

    public Draw(RaceGame raceGame)
    {
        _logic = raceGame;
        _tracks = _logic.tracks;
    }

    public void PlayerDraw(char toWrite, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(toWrite);
    }

    public void TrackDraw()
    {
        var track = _logic.currentTrack;
        var level = _tracks.levels;

        Console.SetCursorPosition(0, 0);
        for(var r = 0; r < level[track].Length; r++)
        {
            for (var c = 0; c < level[track][r].Length; c++)
            {
                Console.Write(level[track][r][c]);
            }
            Console.WriteLine();
        }
    }

    public void PlayerWrite()
    {
        Console.SetCursorPosition(0, 0);
        PlayerDraw(PWrite, _logic.playerX, _logic.playerY); 
    }

    public void ClearOldPos(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(" ");
    }

    public void TimeWrite()
    {
        var pb = _logic.pb.ToString(@"ss\.fff");
        var timeElapsed = _logic.timer.Elapsed.ToString(@"ss\.fff");

        Console.SetCursorPosition(45, 35);
        Console.Write($"Time: {timeElapsed}\n" +
       $"\t\t\t\t\t     Best Time: {pb}");   
    }

    public void AfterGameScreen()
    {
        playerDecide = true;

        Console.Clear();
        Console.SetCursorPosition(0, 0);

        _logic.playerX = 44;
        _logic.playerY = 12;

        var pb = _logic.pb.ToString(@"ss\.fff");
        var timeElapsed = _logic.timer.Elapsed.ToString(@"ss\.fff");

        while (playerDecide)
        {
            Console.SetCursorPosition(35, 5);
            Console.Write($"[Final time: {timeElapsed}]\n\n" +
                $"\t\t\t\t   [Best time: {pb}]\n\n\n\n" +
                $"\t\t\t\t   [ ] \t\t [ ]\n" +
                $"\t\t\t\tPlay again \t Exit");

            PlayerDraw(PWrite, _logic.playerX, _logic.playerY);
            _logic.PlayerMove();
            
        }
        
    }
}
