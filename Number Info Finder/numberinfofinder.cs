class main
{
    static void Main()
    {
        string input = String.Empty;
        List<double> nums = new List<double>();

        Console.WriteLine("\tPlease start inputting numbers: \n" +
                          "\t        End with '!'\n");
        while(true)
        {

            input = Console.ReadLine();

            if (double.TryParse(input, out double result))
            {
                nums.Add(result);
            }
            else
            {
                if (input != "!")
                {
                    Console.WriteLine($"Unable to parse '{input}'");
                } else
                {
                    break;
                }
            }

        }
        Console.Clear();
        Console.WriteLine("\n--------- Resutls: ---------\n");
        Console.WriteLine("   [Sum: " + Plus(nums) + "]");
        Console.WriteLine("   [Product: " + Prod(nums) + "]");
        Console.WriteLine("   [Average: " + Avg(nums) + "]");
        Console.WriteLine("   [Biggest: " + Big(nums) + "]");
        Console.WriteLine("   [Smallest: " + Small(nums) + "]");
        Console.WriteLine("   [Numbers: " + Numbs(nums) + "]\n");

    }

    static double Plus(List<double> num)
    {
        return num.Sum();
    }

    static double Prod(List<double> num)
    {
        //for(int i = 0; i < num.Count; i++)
        //{
        //    if(num[i] == 0)
        //    {
        //        num.RemoveAt(i);
        //    }
        //}
        double r = num.Aggregate((a, x) => a * x);
        return r;
    }

    static double Avg(List<double> num)
    {
        //return num.Average(); Also valid way of doing it.
        return num.Sum() / num.Count;
    }
    static double Big(List<double> num)
    {
        return num.Max();
    }
    static double Small(List<double> num)
    {
        return num.Min();
    }

    static string Numbs(List<double> num)
    {
        return String.Join(", ", num);
    }
}
