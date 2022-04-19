class DecimalToBinary
{
    public static void Main()
    {
        int option;

        Console.WriteLine("Please select a Converter: \n" +
            "\n [1] = Decimal to Binary\n" +
            "\n [2] = Binary to Decimal\n");
        Console.Write("Choice: ");

        option = int.TryParse(Console.ReadLine(), out var _option) ? _option : 0;


        switch (option)
        {
            case 1:
                Console.Clear();
                DtB();
                break;
            case 2:
                Console.Clear();
                BtD();
                break;
            default:
                Console.Clear();
                Main();
                break;
        }
    }

    static void DtB() //Decimal to Binary
    {

        Console.Write("Decimal: ");
        int decimalNumber = int.Parse(Console.ReadLine());

        int remainder;
        string result = string.Empty;
        while (decimalNumber > 0)
        {
            remainder = decimalNumber % 2;

            decimalNumber /= 2;

            result = remainder.ToString() + result;
        }
        Console.WriteLine("Binary:  " + result);
    }
    static void BtD() //Binary to Decimal
    {
        Console.Write("Binary: ");
        string binaryNumber = Console.ReadLine();
        int result = 0;
        for (int i = binaryNumber.Length; i > 0; i--)
            if (binaryNumber.Substring(i - 1, 1) == "1")
            {
                result += (int)Math.Pow(2, (binaryNumber.Length - i));
            }
        Console.WriteLine("Decimal:  " + result);

    }
}