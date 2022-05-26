string word = new WordDictionary().GetRandomWord().ToUpper();
new HangmanGame(word).Run();

public class GameRenderer
{
    public void Render(HangmanGame game)
    {
        Console.Write("Word: ");
        for (int index = 0; index < game.WordToGuess.Length; index++)
        {
            if (game.HasBeenRevealed[index]) Console.Write(game.WordToGuess[index]);
            else Console.Write("_");
            Console.Write(" ");
        }
        Console.Write($"| Remaining: {game.RemainingGuesses} | Incorrect: ");
        foreach (char letter in game.WrongGuesses)
            Console.Write(letter);
        Console.Write(" Guess: ");
    }
}

public class PlayerInput
{
    public char GetGuess()
    {
        return Convert.ToChar(Console.ReadLine().ToUpper());
    }
}

public class HangmanGame
{
    public string WordToGuess;
    public int RemainingGuesses { get; private set; } = 5;
    public bool[] HasBeenRevealed { get; private set; }
    public char[] WrongGuesses { get; private set; }
    
    public HangmanGame(string wordToGuess)
    {
        WordToGuess = wordToGuess;
        HasBeenRevealed = new bool[WordToGuess.Length];
       WrongGuesses = new char[0];
    }

    public void Run()
    {
        GameRenderer renderer = new GameRenderer();
        PlayerInput input = new PlayerInput();
        while (!HasWon() && !HasLost())
        {
            renderer.Render(this);
            char guess = input.GetGuess();

            bool revealedSomething = false;
            for (int index = 0; index < WordToGuess.Length; index++)
            {
                if (WordToGuess[index] == guess)
                {
                    HasBeenRevealed[index] = true;
                    revealedSomething = true;
                }
            }
            if (!revealedSomething)
                RemainingGuesses--;
        }
    }

    public bool HasWon()
    {
        foreach (bool hasBeenRevealed in HasBeenRevealed)
            if (!hasBeenRevealed) return false;
        return true;
    }

    public bool HasLost()
    {
        return RemainingGuesses == 0;
    }
}
public class WordDictionary
{
    public string GetRandomWord()
    {
        Random random = new Random();
        return random.Next(5) switch
        {
            0 => "taco",
            1 => "hamburger",
            2 => "pizza",
            3 => "cheesecake",
            4 => "cake"
        };
    }
}