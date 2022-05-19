int cols = Console.WindowWidth, rows = Console.WindowHeight;
//some sample text
byte[] buffer = Enumerable.Repeat((byte)'=', cols * rows).ToArray();
//because output appends, ensure the window is reset
Console.SetCursorPosition(0, 0);
using (Stream stdout = Console.OpenStandardOutput(cols * rows))
{
    stdout.Write(buffer, 0, buffer.Length);
}