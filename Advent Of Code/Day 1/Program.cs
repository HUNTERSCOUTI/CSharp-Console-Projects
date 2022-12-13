using System;

public class Program
{
    /* Day 1, Puzzle 1
    public static void Main()
    {
        string[] lines = File.ReadAllLines("C:\\Users\\zilas\\source\\repos\\CSharp-Console-Projects\\Advent Of Code\\Day 1\\Calories.txt").ToArray();
        int highestNum = 0;
        int newNum = 0;

        foreach (string line in lines)
        {
            if (line != string.Empty)
            {
                newNum += int.Parse(line);
            }
            else 
            {
                if (newNum > highestNum)
                    highestNum = newNum;
                newNum = 0;
            }
        }
        Console.WriteLine(highestNum);
    }*/

    /* Day 1, Puzzle 2
    public static void Main()
    {
        string[] lines = File.ReadAllLines("C:\\Users\\zilas\\source\\repos\\CSharp-Console-Projects\\Advent Of Code\\Day 1\\Calories.txt").ToArray();

        List<int> nums = new();
        int section = 0;

        foreach (string line in lines)
        {
            if (line != string.Empty)
            {
                section += int.Parse(line);
            } else
            {
                nums.Add(section);
                section = 0;
            }
        }

        Console.WriteLine(nums.Max() + nums.OrderByDescending(z => z).Skip(1).First() + nums.OrderByDescending(z => z).Skip(2).First());
    }
    */
}

