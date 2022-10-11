using static System.Math;

class Program
{
    static float A, B, C;
    static float x, y, z;

    static float cubeWidth = 10;
    static int width = 160;
    static int height = 44;

    static int distanceFromCam = 60;
    static float incrementSpeed = 0.6F;

    public static void Main()
    {
        while (true) 
        {
            for(float cubeX = -cubeWidth; cubeX < cubeWidth; cubeX += incrementSpeed)
            {
                for(float cubeY = -cubeWidth; cubeY < cubeWidth; cubeY += incrementSpeed)
                {
                    CalculateForSurface(cubeX, cubeY, -cubeWidth, '#');
                    CalculateForSurface(cubeWidth, cubeY, cubeX, '$');
                    CalculateForSurface(-cubeWidth, cubeY, -cubeX, '~');
                    CalculateForSurface(-cubeX, cubeY, cubeWidth, '*');
                    CalculateForSurface(cubeX, -cubeWidth, -cubeY, ';');
                    CalculateForSurface(cubeX, cubeWidth, cubeY, '+');
                }
            }

            A += 0.005f;
            B += 0.005f;
            Thread.Sleep(1);
        }
    }

    public static void CalculateForSurface(float cubeX, float cubeY, float cubeZ, char ch)
    {
        x = CalculateX((int)cubeX, (int)cubeY, (int)cubeZ);
        y = CalculateY((int)cubeX, (int)cubeY, (int)cubeZ);
        z = CalculateZ((int)cubeX, (int)cubeY, (int)cubeZ) + distanceFromCam;
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