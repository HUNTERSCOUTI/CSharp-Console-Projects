using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RaceGame;

class RaceGameProgram
{ 
    public static void Main()
    {
        Console.Title = "Race Game";
        Console.SetWindowSize(150, 45);

        var raceGame = new RaceGame();

        raceGame.Run();
    }
}

