using System.Text;
using System.Text.RegularExpressions;

namespace NUnitTestsProject;

[TestFixture]
public class Tests
{
    [Test]
    public static void SpinningWords()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Kata.SpinWords("Welcome"), Is.EqualTo("emocleW"));
            Assert.That(Kata.SpinWords("Hey fellow warriors"), Is.EqualTo("Hey wollef sroirraw"));
            Assert.That(Kata.SpinWords("This is a test"), Is.EqualTo("This is a test"));
            Assert.That(Kata.SpinWords("This is another test"), Is.EqualTo("This is rehtona test"));
            Assert.That(Kata.SpinWords("Almost to the last test"), Is.EqualTo("tsomlA to the last test"));
            Assert.That(Kata.SpinWords("Just kidding there is still one more"), Is.EqualTo("Just gniddik ereht is llits one more"));
        });
    }

    [Test]
    public static void BreakCamelCasing()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Kata.BreakCamelCase("camelCasing"), Is.EqualTo("camel Casing"));
            Assert.That(Kata.BreakCamelCase("camelCasingTest"), Is.EqualTo("camel Casing Test"));
            Assert.That(Kata.BreakCamelCase("thisisnotcamelcase"), Is.EqualTo("thisisnotcamelcase"));
            Assert.That(Kata.BreakCamelCase("butThisIsCamelCase"), Is.EqualTo("but This Is Camel Case"));
        });


        //Random Test Cases
        int amountOfTests = 100;
        int chanceOfUpperCase = 20; // 20% chance per 100th character

        Random rnd = new();

        static string solution(string str)
        {
            return new Regex("([A-Z])").Replace(str, " $1");
        }

        for (int i = 0; i < amountOfTests; ++i)
        {
            StringBuilder sb = new();
            sb.Append((char)rnd.Next(97, 123));
            int length = rnd.Next(10, 1011);

            for (int j = 0; j < length; ++j)
            {
                char c = (char)rnd.Next(97, 123);
                if (rnd.Next(0, chanceOfUpperCase) == 0)
                {
                    c = char.ToUpper(c);
                }
                sb.Append(c);
            }

            string str = sb.ToString();

            string expected = solution(str);
            string actual = Kata.BreakCamelCase(str);

            Assert.That(expected, Is.EqualTo(actual));
        }
    }

    [Test]
    public static void MovingZeros()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Kata.MoveZeroes([1, 2, 0, 1, 0, 1, 0, 3, 0, 1]), Is.EqualTo(new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 }));
            Assert.That(Kata.MoveZeroes([0, 0, 0, 2, 1, 0, 2, 3, 0, 1]), Is.EqualTo(new int[] { 2, 1, 2, 3, 1, 0, 0, 0, 0, 0 }));
            Assert.That(Kata.MoveZeroes([2, 2, 1, 0, 4, 1, 2, 1, 0, 0]), Is.EqualTo(new int[] { 2, 2, 1, 4, 1, 2, 1, 0, 0, 0 }));
        });

        //Random Test Cases
        /*
        int amountOfTests = 10;

        Random rnd = new();

        static string solution(int[] arr)
        {
            
        }

        for (int i = 0; i < amountOfTests; ++i)
        {
            sb.Append((char)rnd.Next(97, 123));
            int length = rnd.Next(10, 200);

            for (int j = 0; j < length; ++j)
            {
                char c = (char)rnd.Next(97, 123);
                if (rnd.Next(0, 5) == 0)
                {
                    c = char.ToUpper(c);
                }
                sb.Append(c);
            }

            string expected = solution(num);
            string actual = Kata.MoveZeroes(num);

            Assert.That(expected, Is.EqualTo(actual));
        }
        */
    }
}