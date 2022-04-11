class Program
{
    static void Main()
    {
        foreach (var color in Enum.GetNames(typeof(CardColor)))
        {
            Console.WriteLine(color);
        }

        foreach (var rank in Enum.GetNames(typeof(CardRank)))
        {
            Console.WriteLine(rank);
        }

        Console.WriteLine($"The {CardColor.Red} {CardRank.Ampersand}");
    }
}

//Define a Card class to represent a card with a color and a rank, as described above
public class Card
{
    //Add properties or methods that tell you if a card is a number or a symbol card (the equivalent of a face card)
    public string Color { get; }
    public string Rank { get; }

    public Card(string color, string rank)
    {
        Color = color;
        Rank = rank;
    }
}

public enum CardColor { Red, Green, Blue, Yellow }
public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand }

//Answer this question: "Why do you think we used a color enumeration here but made a color class in the previous challenge?