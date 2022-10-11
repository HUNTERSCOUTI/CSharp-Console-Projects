using System.Text;


public class Actions
{
    Random rng = new Random();

    public Deck MakeNewDeck()
    {
        Deck deck = new();
        Card card = new();

        List<Card> cards = new();

        foreach (Suits currentSuit in Enum.GetValues(typeof(Suits)))
        {
            for (int i = 1; i <= card.cardsInASuit; i++)
            {
                cards.Add(new Card(i, currentSuit));
            }
        }
        deck.Cards = cards;
        return deck;
    }

    public List<Deck> MakeAmountOfDecks(int amount)
    {
        List<Deck> decks = new List<Deck>();

        for (int i = 0; i < amount; i++)
        {
            decks.Add(MakeNewDeck());
        }

        return decks;
    }

    //Card Name to be printed
    public string NameOfCard(Card card)
    {
        string name;

        switch (card.NumberOnCard)
        {
            case 1:
                name = "A";
                break;
            case 11:
                name = "J";
                break;
            case 12:
                name = "Q";
                break;
            case 13:
                name = "K";
                break;
            default:
                name = card.NumberOnCard.ToString();
                break;
        }

        return name;
    }

    //Shuffle
    public Deck ShuffleDeck(Deck deck)
    {
        for(int i = 52 - 1; i > 0; i--)
        {
            int j = rng.Next(0, i + 1);

            Card temp = deck.Cards[i];
            deck.Cards[i] = deck.Cards[j];
            deck.Cards[j] = temp;
        }
        return deck;
    }
}

public class Deck
{
    Actions actions = new();
    public Deck()
    {

    }

    public Deck(List<Card> cards, int id)
    {
        Cards = cards;
        DeckID = id;
    }

    public int DeckID { get; set; }
    public List<Card> Cards { get; set; }

    // How it's printed
    public override string ToString()
    {
        var sb = new StringBuilder();
        int index = 0;
        while (index < Cards.Count)
        {
            sb.Append($"{actions.NameOfCard(Cards[index])}{Cards[index].SuitOnCard.GetChar()}    ");
            index++;
            if (index % 4 == 0)
            {
                sb.AppendLine();
                sb.AppendLine();
            }
        }
        return sb.ToString();
    }
}

public class Card
{
    public Card()
    {

    }
    public Card(int number, Suits suit)
    {
        NumberOnCard = number;
        SuitOnCard = suit;
    }

    public int NumberOnCard { get; }

    public Suits SuitOnCard { get; }

    public int cardsInASuit = 13;

}

public enum Suits
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}

public static class MyEnumExtensions
{
    public static char GetChar(this Suits value) => value switch 
    { 
        Suits.Clubs => '♣',
        Suits.Diamonds => '♦',
        Suits.Hearts => '♥',
        Suits.Spades => '♠',
    };
}