using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code.Day_2;

public class Program
{
    /* Day 2, Puzzle 1
    public static void Main()
    {
        string[] input = File.ReadAllLines("C:\\Users\\zilas\\source\\repos\\CSharp-Console-Projects\\Advent Of Code\\Day 2\\RPSInput.txt").ToArray();

        // A / X = ROCK
        // B / Y = PAPER
        // C / Z = SCISSORS

        int totalScore = 0;

        foreach (var line in input)
        {
            int pointsGained = 0;
            switch (line[2])
            {
                case 'X':
                    pointsGained += 1;
                    break;
                case 'Y':
                    pointsGained += 2;
                    break;
                case 'Z':
                    pointsGained += 3;
                    break;
            }
            switch (line[0], line[2])
            {
                //Win
                case ('A', 'Y'):
                case ('B', 'Z'):
                case ('C', 'X'):
                    pointsGained += 6;
                    break;
                //DRAW
                case ('A', 'X'):
                case ('B', 'Y'):
                case ('C', 'Z'):
                    pointsGained += 3;
                    break;
                //LOSE
                default:

                    break;
            }
            totalScore = totalScore + pointsGained;
        }
        Console.WriteLine(totalScore);
    }
    */
    /*
    public static void Main()
    {
        string[] input = File.ReadAllLines("C:\\Users\\zilas\\source\\repos\\CSharp-Console-Projects\\Advent Of Code\\Day 2\\RPSInput.txt").ToArray();

        int totalScore = 0;

        // X = LOSE
        // Y = DRAW
        // Z = WIN

        foreach(var line in input)
        {

        }

        Console.WriteLine(totalScore);
    }
    */

    public static void Main()
    {
        ReadWeb();
    }

    public async static Task ReadWeb()
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

        var content = await client.GetStringAsync("https://adventofcode.com/2022/day/2/input");

        Console.WriteLine(content);
    }
}
