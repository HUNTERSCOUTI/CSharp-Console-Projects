

using System.Text;

public class Deck
{

    public Deck(int id)
    {
        Cards = MakeNewDeck();
        DeckID = id;
    }

    public int DeckID { get; set; }
    static readonly Random rng = new Random();
    List<Card> Cards = new();

    public List<Card> MakeNewDeck()
    {
        int cardsInASuit = 13;
        
        foreach (Suits currentSuit in Enum.GetValues(typeof(Suits)))
        {
            for (int i = 1; i <= cardsInASuit; i++)
            {
                Cards.Add(new Card(i, currentSuit));
            }
        }
        return Cards;
    }

    //public ??? AmountOfDecks(int amount)
    //{
    //    List<Deck> decks = new List<Deck>();
    //    List <Card> cards = new List<Card>();

    //    for (int i = 0; i < amount; i++)
    //    {
    //        ???
    //    }

    //    return ???
    //}

    //public ??? Shuffle()
    //{
    //    List sort???
    //}



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

    // How it's printed
    public override string ToString()
    {
        const int spaceBetween = 12;
        var sb = new StringBuilder();
        int index = 0;
        while (index < Cards.Count)
        {
            sb.Append($"{NameOfCard(Cards[index])} of {Cards[index].SuitOnCard}    ");
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