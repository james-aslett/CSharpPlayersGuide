﻿
//MY ORIGINAL WAY START
//create new var of type Color enum as array
//Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow };
//create new var of type Rank enum as array
//Rank[] ranks = new Rank[] { Rank.One, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight, Rank.Nine, Rank.Ten, Rank.Dollar, Rank.Percent, Rank.Caret, Rank.Ampersand };

//nested foreach loop to iterate over each color and each rank and display the combination to console
//foreach (Color color in colors)
//{
//    foreach (Rank rank in ranks)
//    {
//        //create new var of type Card which takes Color/Rank as parameters (see constructor below)
//        Card card = new Card(color, rank);
//        Console.WriteLine($"The {card.Color} {card.Rank}");
//    }
//}
//MY ORIGINAL WAY END

Card[] cards = new Card[4 * 14];


for (int colorNumber = 0; colorNumber < 4; colorNumber++)
    for (int rankNumber = 0; rankNumber < 14; rankNumber++)
        cards[colorNumber * 14 + rankNumber] = new Card((Color)colorNumber, (Rank)rankNumber);


foreach (Card card in cards)
{
    Console.WriteLine($"The {card.Color} {card.Rank}");

}

public class Card
{
    //property of type Color (enum)
    public Color Color { get; }
    //property of type Rank (enum)
    public Rank Rank { get; }

    //constructor takes a Color/Rank enums as parameters
    public Card(Color color, Rank rank)
    {
        //set above properties to parmeter inputs
        Color = color;
        Rank = rank;
    }
    
    //using 'expression body (=>)
    public bool IsSymbol => Rank == Rank.Ampersand || Rank == Rank.Caret || Rank == Rank.Dollar || Rank == Rank.Percent;
    public bool IsNumber => !IsSymbol;
}

public enum Color { Red, Green, Blue, Yellow }
public enum Rank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand }

//Answer this question: "Why do you think we used a color enumeration here but made a color class in the previous challenge?