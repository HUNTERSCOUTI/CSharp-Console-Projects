class head
{

    public static void Main()
    {
        double resultat = 0;
        Console.WriteLine("Velkommen til ConCalc\n" +
            "---------------------\n" +
            "1. Plus\n" +
            "2. Træk fra\n" +
            "3. Gange\n" +
            "4. Dividere\n" +
            "---------------------\n" +
            "Vælg en funktion: ");
        int funktion = int.Parse(Console.ReadLine());
        Console.Write("Tal 1: ");
        int tal1 = int.Parse(Console.ReadLine());
        Console.Write("Tal 2: ");
        int tal2 = int.Parse(Console.ReadLine());
        switch (funktion)
        {
            case 1:
                Console.Write(tal1 + tal2);
                break;
            case 2:
                Console.Write(tal1 - tal2);
                break;
            case 3:
                Console.Write(tal1 * tal2);
                break;
            case 4:
                Console.Write(tal1 / tal2);
                break;
        }
        Console.WriteLine("---------------------\n" +
            $"Resultat: {resultat}\n" +
            "---------------------");
        Console.ReadKey();
    }
}

