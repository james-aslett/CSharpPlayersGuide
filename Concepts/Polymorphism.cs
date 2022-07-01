//Polymorphism lets a derived class supply its own definition ('override') for a member declared in its base class:
 public class ChessPiece
{
    public int Row { get; set; }
    public int Column { get; set; }

    //Marking a member with 'virtual' indicates it can be overridden
    public virtual bool IsLegalMove(int row, int column) =>
            IsOnBoard(row, column) && 
            !IsCurrentLocation(row, column);

    protected bool IsOnBoard(int row, int column) =>
        row >= 0 && row < 8 && column >= 0 && column < 8;

    protected bool IsCurrentLocation(int row, int column) =>
        row == Row && column == Column;
}

public class King : ChessPiece
{
    //Derived classes override a member by marking it with 'override'
    public override bool IsLegalMove(int row, int column)
    {
        if (!base.IsLegalMove(row, column)) return false;

        //Move more than one row or one column is not a legal king move
        if (Math.Abs(row - Row) > 1) return false;
        if (Math.Abs(column - Column) > 1) return false;

        return true;
    }
}

//Classes can leave members unimplemented with 'abstract', but the class must also be abstract. When a class has an abstract method, derived classes
//MUST override the method; there is nothing to fall back on. You cannot create instances on it. 
public abstract class ChessPiece2
{
    //an abtract method MUST be overriden, because there is no supplied definition
    public abstract bool IsLegalMove(int targetRow, int targetColumn);
}