namespace SchoolTaskSQLite;

public static class InputHelper
{
	public static int GetInt(string prompt)
	{
		while (true)
		{
			Console.Write(prompt);
			var input = Console.ReadLine();

			if (int.TryParse(input, out var number))
			{
				return number;
			}

			Console.WriteLine("Sorry, that was not a valid number. Please try again.");
		}
	}

	public static string GetValidatedString(string prompt, Func<string?, bool> validator)
	{
		while (true)
		{
			Console.Write(prompt);
			var input = Console.ReadLine();

			if (validator(input))
			{
				return input;
			}
			
			Console.WriteLine("Sorry, that was not valid. Please try again.");
		}
	}
}