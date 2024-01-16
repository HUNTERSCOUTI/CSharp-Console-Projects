using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code.Day_3;

public class Program
{
    /* Day 3, Puzzle 1
    public static void Main()
    {
        string[] input = File.ReadAllLines("C:\\Users\\zilas\\source\\repos\\CSharp-Console-Projects\\Advent Of Code\\Day 3\\ItemList.txt").ToArray();

        int priority = 0;

        foreach (string line in input)
        {
            char commonItem = ' ';
            string firstHalf = "", secondHalf = "";
            for (int i = 0; i < line.Length/2; i++)
                firstHalf += line[i];
            for (int i = line.Length/2; i < line.Length; i++)
                secondHalf += line[i];

            for(int i = 0; i < line.Length/2; i++)
            {
                if (firstHalf.Contains(secondHalf[i]))
                {
                    commonItem = secondHalf[i];
                }
            }

            priority += char.IsUpper(commonItem) ? commonItem - 38 : commonItem - 96;
        }

        Console.WriteLine(priority);
    }
    */
    
}
