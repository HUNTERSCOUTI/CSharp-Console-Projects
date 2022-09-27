using System;

namespace WineSys;

class WineSysMain
{
    public static void Main()
    {
        int WindowWidth = 100;
        int WindowHeight = 35;

        Console.Title = "Wine Sys";
        Console.SetWindowSize(WindowWidth, WindowHeight);
    }
}