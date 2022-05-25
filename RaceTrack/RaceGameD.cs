using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RaceTrack;

public partial class RaceGame
{
    const char pWrite = '*';

    static string Time = "00.000";

    static string TrackToDraw = string.Empty;

    static void PlayerDraw(char toWrite, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(toWrite);
    }

    static void TrackDraw()
    {
        Console.SetCursorPosition(0, 0);
        Render(LevelSelector(), false);
    }

    public static void PlayerWrite()
    {
        Console.SetCursorPosition(0, 0);
        PlayerDraw(pWrite, pX, pY); 
    }

    public static void Die()
    {
        AfterGameScreen();
    }

    public static void ClearOldPos(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(" ");
    }

    public static void TimeWrite()
    {
        string _pb = pb.ToString(@"ss\.fff");

        Console.SetCursorPosition(45, 13);
        Console.Write($"Time: {TimeCalc(Time)}\n" +
       $"\t\t\t\t\t     Best Time: {_pb}");
        
    }
    
    public static void AfterGameScreen()
    {
        bool playerDecide = true;
        string _endTime = endTime.ToString(@"ss\.fff");
        string _pb = pb.ToString(@"ss\.fff");

        Console.Clear();
        Console.SetCursorPosition(0, 0);
        pX = 44;
        pY = 12;
        while (playerDecide)
        {
            Console.SetCursorPosition(35, 5);
            Console.Write($"[Final time: {_endTime}]\n\n" +
                $"\t\t\t\t   [Best time: {_pb}]\n\n\n\n" +
                $"\t\t\t\t   [ ] \t\t [ ]\n" +
                $"\t\t\t\tPlay again \t Exit");

            PlayerDraw(pWrite, pX, pY);
            PlayerMove();
            
        }
        
    }
}
