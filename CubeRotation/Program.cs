using static System.Math;

class Program
{
    static float A, B, C;
    static float cubeWidth = 10;
    static int width = 160;
    static int height = 44;
    static float[] zBuffer = new float[160 * 40];
    static char[] charBuffer = new char[160 * 44];
    int backgroundASCIIcode = ' ';

    public static void Main()
    {
        while (true)
        {
            
        }
    }

    public static float CalculateX(int i, int j, int k)
    {
        return (float)(j * Sin(A) * Sin(B) * Cos(C) - k * Cos(A) * Sin(B) * Cos(C) + j * Cos(A) * Sin(C) + k * Sin(A) * Sin(C) + i * Cos(B) * Cos(C));
    }

    public static float CalculateY(int i, int j, int k)
    {
        return (float)(j * Cos(A) * Cos(C) - j * Sin(A) * Sin(B) * Sin(C) + k * Cos(A) * Sin(B) * Sin(C) - i * Cos(B) * Sin(C));
    }

    public static float CalculateZ(int i, int j, int k)
    {
        return (float)(k * Cos(A) * Cos(B) - j * Sin(A) * Cos(B) + i * Sin(B));
    }
}