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
            PlayerChoice choice1 = _player1.GetChoice(_player1.Name);
            PlayerChoice choice2 = _player2.GetChoice(_player2.Name);
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
        if (choice1 == PlayerChoice.Scissors && choice2 == PlayerChoice.Paper 
            || choice1 == PlayerChoice.Rock && choice2 == PlayerChoice.Scissors
            || choice1 == PlayerChoice.Paper && choice2 == PlayerChoice.Rock) return 1;
        else if (choice1 == PlayerChoice.Paper && choice2 == PlayerChoice.Scissors
            || choice1 == PlayerChoice.Scissors && choice2 == PlayerChoice.Rock
            || choice1 == PlayerChoice.Rock && choice2 == PlayerChoice.Paper) return 2;
        else return 0;
    }
}

public class Player
{
    public string Name { get; set; }

    public PlayerChoice GetChoice(string player)
    {
        Console.WriteLine($"{player}, please make a choice from Rock, Paper or Scissors.");  
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