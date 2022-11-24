using System;
using System.Text;

public class Kata
{
    public static void Main()
    {
        Console.WriteLine(Likes(new string[0]));
        Console.WriteLine(Likes(new string[] { "Peter" }));
        Console.WriteLine(Likes(new string[] { "Jacob", "Alex" }));
        Console.WriteLine(Likes(new string[] { "Max", "John", "Mark" }));
        Console.WriteLine(Likes(new string[] { "Alex", "Jacob", "Mark", "Max" }));
    }

    public static string Likes(string[] name)
    {
        
    }
}