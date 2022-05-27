using System;

namespace RaceTrack;

public partial class RaceGame
{
    const char pWrite = '*';

    static bool playerDecide = true;

    static void PlayerDraw(char toWrite, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(toWrite);
    }

    static void TrackDraw()
    {
        Console.SetCursorPosition(0, 0);
        for(int r = 0; r < Levels[currentTrack].Length; r++)
        {
            for (int c = 0; c < Levels[currentTrack][r].Length; c++)
            {
                Console.Write(Levels[currentTrack][r][c]);
            }
            Console.WriteLine();
        }
    }

    public static void PlayerWrite()
    {
        Console.SetCursorPosition(0, 0);
        PlayerDraw(pWrite, playerX, playerY); 
    }

    public static void ClearOldPos(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(" ");
    }

    public static void TimeWrite()
    {
        string _pb = pb.ToString(@"ss\.fff");

        Console.SetCursorPosition(45, 35);
        Console.Write($"Time: {timer.Elapsed.ToString(@"ss\.fff")}\n" +
       $"\t\t\t\t\t     Best Time: {_pb}");   
    }

    public static void AfterGameScreen()
    {
        playerDecide = true;

        Console.Clear();
        Console.SetCursorPosition(0, 0);
        playerX = 44;
        playerY = 12;
        while (playerDecide)
        {
            Console.SetCursorPosition(35, 5);
            Console.Write($"[Final time: {timer.Elapsed.ToString("ss\\.fff")}]\n\n" +
                $"\t\t\t\t   [Best time: {pb.ToString("ss\\.fff")}]\n\n\n\n" +
                $"\t\t\t\t   [ ] \t\t [ ]\n" +
                $"\t\t\t\tPlay again \t Exit");

            PlayerDraw(pWrite, playerX, playerY);
            PlayerMove();
            
        }
        
    }
}
