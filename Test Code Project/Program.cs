using Newtonsoft.Json;

class Program
{
    public static List<Sales> sales = new List<Sales>();
    public static void Main()
    {
        //JSON
        if (File.Exists("sales.json"))
        {
            Console.WriteLine("Sales file found, deserializing it...\n\n");
            string fileStr = File.ReadAllText("sales.json");
            sales = JsonConvert.DeserializeObject<List<Sales>>(fileStr) ?? new List<Sales>();
        }

        Console.WriteLine("Welcome to Sales People Force Program");
        while (true) // Main Loop
        {
            Console.Write("\nHow many peoples You want to enter : ");
            string size = Console.ReadLine();

            if (isNumeric(size))
            {
                int n = Convert.ToInt32(size);
                for (int i = 0; i < n; i++)
                {
                    Sales sale = new Sales();
                    Console.Write("Enter Name : ");
                    sale.Name = Console.ReadLine();

                    Console.Write("Enter SS Number : ");
                    sale.SSNumber = Console.ReadLine();

                    Console.Write("Enter District Name : ");
                    sale.District = Console.ReadLine();

                    Console.Write("Enter Items Sold : ");
                    sale.ItemsSold = Convert.ToInt32(Console.ReadLine());

                    levelCalc(sale.ItemsSold, sale);

                    sales.Add(sale); // Add to list

                    Console.WriteLine();
                }

                // JSON
                string strResultJson = JsonConvert.SerializeObject(sales);
                File.WriteAllText(@"sales.json", strResultJson + "\t");

                List<Sales> SortedList = sales.OrderByDescending(s => s.ItemsSold).ToList(); // Sorts in Descending order

                Console.Clear();

                WriteStats(SortedList);

                break;
            }
            else
            {
                Console.WriteLine("kindly enter correct Number ..!!\n");
            }   
        }
    }
    static void WriteStats(List<Sales> salesSorted)
    {
        Console.WriteLine("Name: SSNumber: District: Items: Level:\n" +
                           "------------------------------------------------");
        int count = 0;
        int? level = null;
        foreach (var item in salesSorted.OrderBy(x => x.Level))
        {
            if (item.Level != level) //If the item level doens't match the current level, it will go to the next level "holder"
            {
                if (level is not null)
                {
                    Console.WriteLine($"{count} sellers reached level {level}");
                    count = 0;
                }
                level = item.Level;
            }
            Console.WriteLine(item);
            count++;
        }
        if (count > 0)
        {
            Console.WriteLine($"{count} sellers reached level {level}");
        }


        Console.WriteLine("\n\nFile can be found in 'projectfolder.bin.Debug.net6.0.sales.json'");
        Console.WriteLine("Press any key to close...");
        Console.ReadKey(true);
    }

    static bool isNumeric(string s)
    {
        return int.TryParse(s, out int n); //Is it a number?
    }

    public static void levelCalc(int num, Sales sale) // sets the level 
    {
        if (num < 50)
        {
            sale.Level = 1;
        }
        else if (num >= 50 && num <= 99)
        {
            sale.Level = 2;
        }
        else if (num >= 100 && num <= 199)
        {
            sale.Level = 3;
        }
        else if (num > 199)
        {
            sale.Level = 4;
        }
    }
}
public class Sales // Viewmodel for sales
{
    public string? Name { get; set; }

    public string? SSNumber { get; set; }

    public string? District { get; set; }

    public int ItemsSold { get; set; }

    public int Level { get; set; }

    public override string ToString() => $"{Name}\t  {SSNumber}\t  {District}\t  {ItemsSold}\t  {Level}";
    //Overrides the string that will be displayed and will print it in the way I want it to. Using String interpolation to print it with the variables in it.
}