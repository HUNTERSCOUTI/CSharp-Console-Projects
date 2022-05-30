using System;

namespace RaceGame;

public class Draw
{
    readonly RaceGame logic;
    readonly Tracks tracks;

    public const char pWrite = '*';

    public bool playerDecide = true;

    public Draw(RaceGame raceGame)
    {
        logic = raceGame;
        tracks = logic.Tracks;
    }

    public void PlayerDraw(char toWrite, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(toWrite);
    }

    public void TrackDraw()
    {
        var track = logic.currentTrack;
        var level = tracks.Levels;

        Console.SetCursorPosition(0, 0);
        for(int r = 0; r < level[track].Length; r++)
        {
            for (int c = 0; c < level[track][r].Length; c++)
            {
                Console.Write(level[track][r][c]);
            }
            Console.WriteLine();
        }
    }

    public void PlayerWrite()
    {
        Console.SetCursorPosition(0, 0);
        PlayerDraw(pWrite, logic.playerX, logic.playerY); 
    }

    public void ClearOldPos(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(" ");
    }

    public void TimeWrite()
    {
        logic.pb.ToString(@"ss\.fff");

        Console.SetCursorPosition(45, 35);
        Console.Write($"Time: {logic.timer.Elapsed.ToString(@"ss\.fff")}\n" +
       $"\t\t\t\t\t     Best Time: {logic.pb}");   
    }

    public void AfterGameScreen()
    {
        playerDecide = true;

        Console.Clear();
        Console.SetCursorPosition(0, 0);
        logic.playerX = 44;
        logic.playerY = 12;
        while (playerDecide)
        {
            Console.SetCursorPosition(35, 5);
            Console.Write($"[Final time: {logic.timer.Elapsed.ToString("ss\\.fff")}]\n\n" +
                $"\t\t\t\t   [Best time: {logic.pb.ToString("ss\\.fff")}]\n\n\n\n" +
                $"\t\t\t\t   [ ] \t\t [ ]\n" +
                $"\t\t\t\tPlay again \t Exit");

            PlayerDraw(pWrite, logic.playerX, logic.playerY);
            logic.PlayerMove();
            
        }
        
    }
}
