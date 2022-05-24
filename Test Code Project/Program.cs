class program
{
    public static void Main()
    {

    }
    public static string test()
    {
        Console.WriteLine("bla bal");
        var Store = Console.ReadLine();
        return Store;
    }

    static string epicstore = string.Empty;
    public static bool cI()
    {
        epicstore = test();

        if (int.Parse(test()) == 1)
        {
            return false;
        }
        return true;
    }
}