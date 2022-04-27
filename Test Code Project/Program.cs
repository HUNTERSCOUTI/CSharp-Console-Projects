class Program
{
    public static void Main()
    {
        Console.WriteLine("Random Sort");
        Console.Write("Enter elements of the array:");

        var parts = Console.ReadLine().Split(new[] { "", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var array = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            array[i] = Convert.ToInt32(parts[i]);
        }

        Console.WriteLine("Sorted array: {0}", string.Join(",", BogoSort(array)));

        Console.ReadLine();
    }

    static int[] Shuffle(int[] a)
    {
        Random random = new Random();
        var n = a.Length;
        while (n > 1)
        {
            n--;
            var i = random.Next(n + 1);
            var temp = a[i];
            a[i] = a[n];
            a[n] = temp;
        }

        return a;
    }

    static bool IsSorted(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            if (a[i] > a[i + 1])
                return false;
        }

        return true;
    }

    static int[] BogoSort(int[] a)
    {
        while (!IsSorted(a))
        {
            a = Shuffle(a);
        }

        return a;
    }
}

