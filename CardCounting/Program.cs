

public class Program
{
    public static void Main()
    {
        int newDeckID = 0;

        Deck deck1 = new Deck(newDeckID++);
        Deck deck2 = new Deck(newDeckID++);

        List<Deck> Decks = new List<Deck>();
        Decks.Add(deck1);
        Decks.Add(deck2);



        Console.WriteLine();
    }
}