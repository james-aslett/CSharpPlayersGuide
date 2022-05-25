string word = new WordDictionary().GetRandomWord();

public class GameRenderer
{
    public void Render(HangmanGame game)
    {
        
    }
}

public class HangmanGame
{
    private readonly string _wordToGuess;
    private int _remainingGuesses;
    public bool[] HasBeenRevelead { get; private set; }
    public char[] WrongGuesses { get; private set; }
    
    public HangmanGame(string wordToGuess)
    {
        _wordToGuess = wordToGuess;
        HasBeenRevelead = new bool[_wordToGuess.Length];
       WrongGuesses = new char[0];
    }

    public void Run()
    {
        GameRenderer renderer = new GameRenderer();
        while (!HasWon() && !HasLost())
        {
            renderer.Render(this);
        }
    }

    public bool HasWon()
    {
        foreach (bool hasBeenRevealed in _hasBeenRevelead)
            if (!hasBeenRevealed) return false;
        return true;
    }

    public bool HasLost()
    {
        return _remainingGuesses == 0;
    }
}
public class WordDictionary
{
    public string GetRandomWord()
    {
        Random random = new Random();
        return random.Next() switch
        {
            0 => "taco",
            1 => "hamburger",
            2 => "pizza",
            3 => "cheesecake",
            4 => "cake"
        };
    }
}