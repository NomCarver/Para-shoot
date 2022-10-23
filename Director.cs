/// Controls sequence of play
public class Director
{
    private bool isPlaying = true;
    private string chosenWord;
    private TerminalService terminalService = new TerminalService();
    public HiddenWord hiddenWord = new HiddenWord();
    private Jumper jumper = new Jumper();
    public int tries = 0;
    public int numberOfGuesses = 0;
    private bool checkInput;
    List<char> guessedLetters = new List<char>();
    public string currentGuess = "test";

    /// Constructs a new instance of Director
    public Director()
    {
    }

    /// Starts the game by running the main game loop.
    public void StartGame()
    {
        StartUp();
        while (isPlaying)
        {
            GetInputs();
            DoUpdates();
            DoOutputs();
        }
    }

    private void StartUp()
    {
        Console.WriteLine("\nHint: This class");
        chosenWord = hiddenWord.pullWord();
        hiddenWord.listWord(chosenWord);
        hiddenWord.createHiddenWord();
        hiddenWord.printGuess();
    }
    private void GetInputs()
    {
        Console.WriteLine("\n");
        jumper.printJumper(tries);
        checkInput = true;
        while (checkInput)
        {
            currentGuess = terminalService.ReadGuess("\nGuess a letter [a-z]: ");
            checkInput = jumper.checkInput(guessedLetters, currentGuess);
        }
        guessedLetters.Add(currentGuess[0]);
            
    }

    private void DoUpdates()
    {
        numberOfGuesses = guessedLetters.Count;
        int usedTries = hiddenWord.compare(guessedLetters, numberOfGuesses);
        tries = tries + usedTries;
        isPlaying = jumper.checkJumper(hiddenWord.guess, tries);
    }

    private void DoOutputs()
    {
        Console.WriteLine("\n");
        if (isPlaying){
            hiddenWord.printGuess();
        }
        else {
            jumper.printJumper(tries);
            hiddenWord.printAnswer();
            Console.WriteLine("\n");
        }
    }
}