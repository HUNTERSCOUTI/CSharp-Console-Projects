
using System.Diagnostics;

ConsoleRenderer.Initialize();
var lastTime = DateTime.Now;
float deltaTime = 0.0f;
while (true)
{
    var currentTime = DateTime.Now;
    deltaTime += (currentTime - lastTime).Ticks / 10000000f;
    lastTime = currentTime;

    var (s, c) = Math.SinCos(deltaTime * 2);

    // Render
    ConsoleRenderer.Clear(' ');
    ConsoleRenderer.DrawLine(
        10 - (int)(c * 8),
        10 - (int)(s * 8),
        10 + (int)(c * 8),
        10 + (int)(s * 8),
        'X');
    ConsoleRenderer.Show();
}

public static class ConsoleRenderer
{
    private static Stream stream = Stream.Null;
    private static byte[] buffer = Array.Empty<byte>();

    public static int Width { get; private set; }
    public static int Height { get; private set; }

    public static void Initialize()
    {
        stream = Console.OpenStandardOutput();
        Width = Console.WindowWidth;
        Height = Console.WindowHeight;
        buffer = new byte[Width * Height];
    }

    // https://en.wikipedia.org/wiki/Bresenham%27s_line_algorithm
    public static void DrawLine(int x0, int y0, int x1, int y1, char ch)
    {
        void Low(int x0, int y0, int x1, int y1)
        {
            var dx = x1 - x0;
            var dy = y1 - y0;

            var yi = 1;
            if (dy < 0)
            {
                yi = -1;
                dy = -dy;
            }
            var D = (2 * dy) - dx;
            var y = y0;

            Debug.Assert(x0 <= x1);
            for (var x = x0; x <= x1; ++x)
            {
                Plot(x, y, ch);
                if (D > 0)
                {
                    y += yi;
                    D += (2 * (dy - dx));
                }
                else
                {
                    D += 2 * dy;
                }
            }
        }

        void High(int x0, int y0, int x1, int y1)
        {
            var dx = x1 - x0;
            var dy = y1 - y0;

            var xi = 1;
            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }
            var D = (2 * dx) - dy;
            var x = x0;

            Debug.Assert(y0 <= y1);
            for (var y = y0; y <= y1; ++y)
            {
                Plot(x, y, ch);
                if (D > 0)
                {
                    x += xi;
                    D += (2 * (dx - dy));
                }
                else
                {
                    D += 2 * dx;
                }
            }
        }

        if (Math.Abs(y1 - y0) < Math.Abs(x1 - x0))
        {
            if (x0 > x1) Low(x1, y1, x0, y0);
            else Low(x0, y0, x1, y1);
        }
        else
        {
            if (y0 > y1) High(x1, y1, x0, y0);
            else High(x0, y0, x1, y1);
        }
    }

    public static void Clear(char ch) => Array.Fill(buffer, (byte)ch);

    public static void Plot(int x, int y, char ch) =>
        buffer[x + y * Width] = (byte)ch;

    public static void Show()
    {
        Console.SetCursorPosition(0, 0);
        stream.Write(buffer);
    }
}