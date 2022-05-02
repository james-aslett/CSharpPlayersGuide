//Two players take turns entering their choice using the same keyboard.
//The players designate which square they want to play in. Hint: you might consider using the number pad as a guide. For example, if they enter 7, they have chosen
//the top left corner of the board.
//The game should prevent players from choosing squares that are already occupied. If such a move is attempted, the player should be told of the problem and given another
//chance.
//The game must detect when a player wins or when the board is full with no winner (draw/"cat")
//When the game is over the outcome is displayed.
//The state of the board must be displayed to the player after each play. Hint: one possible way to show the board could be like this:

//It is X's turn.
//   | X |
//---|---|---
//   | 0 | X
//---|---|---
// 0 |   | X

//OBJECTIVES:
//Build the game of Tic-Tac-Toe as described in the requirements above. Starting with CRC cards is recommended, but the goal is to make working software, not CRC cards.
//Answer this question: How might you modify your completed program if running multiple rounds was a requirement (eg: best of 5)?

//MAIN METHOD


class TicTacToe
{

}

class Player
{
    public int GetUserInput()
    {
        return Convert.ToInt32(Console.ReadLine());
    }
}

