
/// Provide input and output operations for the Terminal 
public class TerminalService
{
    /// Constructs a new instance of TerminalService.
    public TerminalService()
    {
    }

    /// Gets numerical input from the TerminalService. Directs the user with the given prompt.
    public string ReadGuess(string prompt)
    {
        string rawValue = ReadText(prompt);
        return rawValue;
    }

    /// Gets text input from the Terminal. Directs the user with the given prompt
    public string ReadText(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    /// Displays the given text on the Terminal 
    public void WriteText(string text)
    {
        Console.WriteLine(text);
    }
}