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
    const char wallV = '║'; // NOT USED CURRENTLY
    const char wallH = '═'; // NOT USED CURRENTLY

    static string Time = string.Empty;

    private static Stream stream = Stream.Null;  //Make an empty streamer
    private static byte[] buffer = Array.Empty<byte>();  //Empty Array with byte as DataType

    public static int Width { get; private set; }
    public static int Height { get; private set; }

    public static void StreamBufferInitialize()
    {
        stream = Console.OpenStandardOutput();  //Get's standard output stream
        Width = 108;
        Height = 30;
        buffer = new byte[Width * Height];  //Sets the buffer to width * height in bytes
    }

    public static void GameWrite()
    {
        Console.SetCursorPosition(0, 0);
        PlayerDraw(pWrite, pX, pY);
        stream.Write(buffer);  
    }

    public static void TimeWrite()
    {
        Console.SetCursorPosition(45, 13);
        Console.Write(TimeCalc(Time));
    }
    

}
