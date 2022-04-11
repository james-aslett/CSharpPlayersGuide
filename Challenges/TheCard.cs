//Create a Main method that will create a card instance for the whole deck (every color with every rank) and display each (for example,
//"The Red Ampersand" and "The Blue Seven"



//Create a card to represent playing cards. Each card has:
//    a color (red, green, blue, yellow)
//    a rank (1 - 10, followed by the symbols $, %, ^, and &)

//Define a Card class to represent a card with a color and a rank, as described above
public class Card
{
    public Color {get;}

    public Card(string color, string rank)
    {

    }
 
    //Add properties or methods that tell you if a card is a number or a symbol card (the equivalent of a face card)



}

//Define enumerations for card colors and ranks
public enum CardColor { Red, Green, Blue, Yellow }
public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand
}

//Answer this question: "Why do you think we used a color enumeration here but made a color class in the previous challenge?