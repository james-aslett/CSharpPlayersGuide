//write a main method that creates a few coordinates and determines if they are adjacent to each other to prove that it is working correctly
Coordinate a = new Coordinate(3, 3);
Coordinate b = new Coordinate(2, 3);
Coordinate c = new Coordinate(2, 2);

Console.WriteLine(Coordinate.AreAdjacent(a, b)); //true
Console.WriteLine(Coordinate.AreAdjacent(b, c)); //true
Console.WriteLine(Coordinate.AreAdjacent(a, c)); //false
Console.WriteLine(Coordinate.AreAdjacent(a, a)); //false (coordinates match so not technically adjacent)

//create a coordinate struct that can represent a room coordinate with a row/column - done
//ensure Coordinate is immutable - done(?)
public struct Coordinate
{
    public int Row { get; }
    public int Column { get; } 
    
    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    //make a method to determine if one coordinate is adjacent to another (differing only by a single row/column)
    public static bool AreAdjacent(Coordinate a, Coordinate b)
    {
        int rowChange = a.Row - b.Row;
        int columnChange = a.Column - b.Column;

        if (Math.Abs(rowChange) == 0 && columnChange == 0) return false; //if adjacent to itself, we'll class it as false
        if (Math.Abs(rowChange) <= 1 && columnChange == 0) return true;
        if (Math.Abs(columnChange) <= 1 && rowChange == 0) return true;

        return false;
    }
}