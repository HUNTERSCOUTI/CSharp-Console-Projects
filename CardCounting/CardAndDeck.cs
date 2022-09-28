using System.Text;


public class Actions
{
    public Deck deck = new();

    public List<Card> MakeNewDeck()
    {
        int cardsInASuit = 13;
        List<Card> cards = new();

        foreach (Suits currentSuit in Enum.GetValues(typeof(Suits)))
        {
            for (int i = 1; i <= cardsInASuit; i++)
            {
                cards.Add(new Card(i, currentSuit));
            }
        }
        return cards;
    }

    public List<Deck> AmountOfDecks(int amount)
    {
        List<Deck> decks = new List<Deck>();
        List<Card> cards = new List<Card>();

        for (int i = 0; i < amount; i++)
        {

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
                name = "Ace";
                break;
            case 11:
                name = "Jack";
                break;
            case 12:
                name = "Queen";
                break;
            case 13:
                name = "King";
                break;
            default:
                name = card.NumberOnCard.ToString();
                break;
        }

        return name;
    }

    //Shuffle
    public void Shuffle()
    {
        
    }
}

public class Deck
{
    public Actions actions = new();
    public Deck()
    {

    }

    public Deck(int id)
    {
        Cards = actions.MakeNewDeck();
        DeckID = id;
    }

    public int DeckID { get; set; }
    public List<Card> Cards = new();

    // How it's printed
    public override string ToString()
    {
        var sb = new StringBuilder();
        int index = 0;
        while (index < Cards.Count)
        {
            sb.Append($"{actions.NameOfCard(Cards[index])} of {Cards[index].SuitOnCard}    ");
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
    public Card(int number, Suits suit)
    {
        NumberOnCard = number;
        SuitOnCard = suit;
    }

    public int NumberOnCard { get; }

    public Suits SuitOnCard { get; }

}

public enum Suits
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}