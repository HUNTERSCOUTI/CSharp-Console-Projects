using Match3;
using System.Runtime.InteropServices;


public class Match3Program
{
    #region Fullscreen Variables
    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();
    private static IntPtr ThisConsole = GetConsoleWindow();
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private const int HIDE = 0;
    private const int MAXIMIZE = 3;
    private const int MINIMIZE = 6;
    private const int RESTORE = 9;
    #endregion

    public static void Main()
    {
        Console.Title = "Match 3";
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        ShowWindow(ThisConsole, MAXIMIZE);

        var game = new Match3Game();
        game.Run();
    }
}



public class Match3Game
{
    private GameState _state;
    private const int YNumPos = 45;

    private static readonly int[] XNumPos = new int[] { 86, 92, 98 };
    private static readonly int[] PlaceX = new int[] { 26, 52, 78, 104, 130, 156 };
    private static readonly int[] PlaceY = new int[] { 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };

    public void Run()
    {
        _state = new GameState(6, 11);

        while (_state.Guess < 3)
        {
            Print();
            PlayerMove();
        }
    }

    private void PlayerMove()
    {
        Console.SetCursorPosition(XNumPos[_state.Guess], YNumPos);
        bool stopLoop = false;

        while (!stopLoop)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    PickColumn(0);
                    stopLoop = true;
                    break;
                case ConsoleKey.D2:
                    PickColumn(1);
                    stopLoop = true;
                    break;
                case ConsoleKey.D3:
                    PickColumn(2);
                    stopLoop = true;
                    break;
                case ConsoleKey.D4:
                    PickColumn(3);
                    stopLoop = true;
                    break;
                case ConsoleKey.D5:
                    PickColumn(4);
                    stopLoop = true;
                    break;
                case ConsoleKey.D6:
                    PickColumn(5);
                    stopLoop = true;
                    break;
            }
        }
    }

    public void PickColumn(int columnIndex)
    {
        var result = _state.TakeNumber(columnIndex);
        _state.AddGuess(result);
    }

    private void Print()
    {
        DrawBoard();
        DrawNums();
        
    }

    private void DrawNums()
    {
        int y = 0;
        for (int i = 0; i < 36; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (_state.BoardNumbers[j, y].Available)
                {
                    Console.SetCursorPosition(PlaceX[j], PlaceY[y]);
                    Console.Write(_state.BoardNumbers[j, y].Value);  
                }
            }
            y++;
            if (y == PlaceY.Length) y = 0;
        }
    }

    public void DrawBoard()
    {
        #region Edges
        //Top and Bottom
        Console.SetCursorPosition(13, 2);
        for (int i = 0; i < 157; i++)
        {
            Console.Write("*");
        }
        Console.SetCursorPosition(13, 49);
        for (int i = 0; i < 157; i++)
        {
            Console.Write("*");
        }

        //Sides
        for (int j = 3; j < 49; j++)
        {
            Console.SetCursorPosition(169, j);
            Console.Write("|");
        }
        for (int j = 3; j < 49; j++)
        {
            Console.SetCursorPosition(13, j);
            Console.Write("|");
        }
        #endregion

        #region Bottom Box
        Console.SetCursorPosition(83, YNumPos - 1);
        Console.Write("*******************");
        Console.SetCursorPosition(83, YNumPos);
        Console.Write("|     |     |     |");
        Console.SetCursorPosition(83, YNumPos + 1);
        Console.Write("*******************");
        #endregion

        #region Bottom Numbers
        int botNums = 1;
        for (int i = 0; i < PlaceX.Length; i++)
        {
            Console.SetCursorPosition(PlaceX[i] - 1, 42);
            Console.Write("[" + botNums + "]");
            botNums++;
        }
        #endregion


    }
}

//OLD CODE = https://paste.mod.gg/lbnujzipoypu/0