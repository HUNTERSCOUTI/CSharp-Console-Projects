

public class Program
{
    public static List<Deck> CurrentDecksInUse = new();
    public static void Main()
    {
        Actions actions = new();

        int newDeckID = 0;

        List<Deck> Decks = new List<Deck>();


        Console.WriteLine("How many decks?");
        int amount;
        amount = int.TryParse(Console.ReadLine(), out var _amount) ? _amount : 0;

        CurrentDecksInUse = actions.MakeAmountOfDecks(amount);

        foreach(var deck in CurrentDecksInUse)
        {
            actions.ShuffleDeck(deck);
            Console.WriteLine(deck);
        }
        

    }
}