RockPaperScissorsGame game = new RockPaperScissorsGame();
game.Run();

public class RockPaperScissorsGame
{
    private Player _player1;
    private Player _player2;
    private HistoricalRecord _history;

    public RockPaperScissorsGame()
    {
        _player1 = new Player() { Name = "James" };
        _player2 = new Player() { Name = "Rae" };
        _history = new HistoricalRecord();
    }

    public void Run()
    {
        while (true)
        {
            PlayerChoice choice1 = _player1.GetChoice();
            PlayerChoice choice2 = _player2.GetChoice();
            int winner = DetermineWinner(choice1, choice2);
            DisplayOutcome(winner);
            UpdateHistoricalRecord(winner);
        }
    }

    private void UpdateHistoricalRecord(int winner)
    {
        if (winner == 0) _history.Draws++;
        else if (winner == 1) _history.Player1Wins++;
        else _history.Player2Wins++;
    }

    private void DisplayOutcome(int winner)
    {
        if (winner == 0) Console.WriteLine("It's a draw!");
        else if (winner == 1) Console.WriteLine($"{_player1.Name} wins!");
        else Console.WriteLine($"{_player2.Name} wins!");
    }

    private int DetermineWinner(PlayerChoice choice1, PlayerChoice choice2)
    {
        //check game logic
        //return 1 if player 1 | 2 if player 2 | 0 if draw
    }
}

public class Player
{
    public string Name { get; set; }

    public PlayerChoice GetChoice()
    {
        PlayerChoice input = (PlayerChoice)Enum.Parse(typeof(PlayerChoice), Console.ReadLine(), true);

        return input switch
        {
            PlayerChoice.Rock => PlayerChoice.Rock,
            PlayerChoice.Paper => PlayerChoice.Paper,
            PlayerChoice.Scissors => PlayerChoice.Paper,
            _ => 0,
        };
    }
}

public class HistoricalRecord
{
    public int Player1Wins { get; set; }
    public int Player2Wins { get; set; }
    public int Draws { get; set; }
}

public enum PlayerChoice { Rock, Paper, Scissors }