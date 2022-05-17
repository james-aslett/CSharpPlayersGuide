

public class Board
{
    private int[,] _squares; //numbers 1 through 16, and 16 is open slot
                             // [Row, Column]
    public Board()
    {
        _squares = new int[4, 4];

        //loop through 2D array
        for (int row = 0; row < 4; row++)
            for (int column = 0; column < 4; column++)
                _squares[row, column] = row * 4 + column + 1;

    }
}

