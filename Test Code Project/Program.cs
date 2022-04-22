class Program
{
    public static void Main()
    {
        double resultat = 0;
        string tal1, tal2;
        Console.WriteLine("[Velkommen til ConCalc]\n" +
            "---------------------\n" +
            "1. Plus\n" +
            "2. Træk fra\n" +
            "3. Gange\n" +
            "4. Dividere\n" +
            "5. Nettoløn Beregner" +
            "---------------------\n" +
            "Vælg en funktion");
        string funktion = Console.ReadLine();
        if (funktion != "5")
        {
            Console.Write("Tal 1: ");
            tal1 = Console.ReadLine();
            Console.Write("Tal 2: ");
            tal2 = Console.ReadLine();
            resultat = 0;
            if (funktion == "1")
            {
                resultat = Convert.ToDouble(tal1) + Convert.ToDouble(tal2);
            }
            else if (funktion == "2")
            {
                resultat = Convert.ToDouble(tal1) - Convert.ToDouble(tal2);
            }
            else if (funktion == "3")
            {
                resultat = Convert.ToDouble(tal1) * Convert.ToDouble(tal2);
            }
            else
            {
                resultat = Convert.ToDouble(tal1) / Convert.ToDouble(tal2);
            }
        } else if (funktion == "5")
        {
            Console.Clear();
            NettoBeregner();
        } else
        {
            Console.WriteLine("Ugyldigt input");
        }
        Console.WriteLine("---------------------\n" +
            "Resultat\n" +
            $"{resultat}\n" +
            "---------------------\n" +
            "Tryk ESC for at genstarte");
        if (Console.ReadKey().Key == ConsoleKey.Escape)
        {
            Main();
        } else
        {
            Console.WriteLine("Hav en god dag");
        }
    }
    
    public static double NettoBeregner()
    {
        Console.WriteLine();
        return 0;
    }

}
