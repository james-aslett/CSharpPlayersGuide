//create a coordinate struct that can represent a room coordinate with a row/column - done
public struct Coordinate
{
    private readonly float Row;
    private readonly float Column;

    public Coordinate(float row, float column)
    {
        Row = row;
        Column = column;
    }
}

//ensure Coordinate is immutable - done

//make a method to determine if one coordinate is adjacent to another (differing only by a single row/column)

//write a main method that creates a few coordinates and determines if they are adjacent to each other to prove that it is working correctly