using System.Collections.Generic;
using System.Linq;
using System;
using NUnit.Framework;

public class Kata
{
    static void Main(string[] args) { } //Empty on purpose

    // https://www.codewars.com/kata/5264d2b162488dc400000001/csharp
    public static string SpinWords(string sentence)
    {
        string[] arr = sentence.Split(' ');
        string result = "";

        foreach (string word in arr)
        {
            if (word.Length >= 5)
            {
                char[] charArray = word.ToCharArray();
                Array.Reverse(charArray);
                result += new string(charArray) + " ";
            }
            else
            {
                result += word + " ";
            }
        }
        return result.TrimEnd();
    }

    // https://www.codewars.com/kata/5208f99aee097e6552000148/csharp
    public static string BreakCamelCase(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsUpper(str[i]))
            {
                str = str.Insert(i, " ");
                i++;
            }
        }
        return str;
    }

    // https://www.codewars.com/kata/52597aa56021e91c93000cb0/csharp
    public static int[] MoveZeroes(int[] arr)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                arr[count++] = arr[i];
            }
        }
        while (count < arr.Length)
        {
            arr[count++] = 0;
        }

        return arr;
    }
}