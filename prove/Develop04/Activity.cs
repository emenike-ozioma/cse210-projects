using System.Diagnostics.Tracing;

public class Activity
{
    // Attribute
    protected string _name; // The activity name
    protected string _description; // The description
    protected int _duration; // The duration in seconds

    // Constructor
    public Activity()
    {
        _name = "Activity";
        _description = "Undefined";
        _duration = 10;
    }

    // Method
    public void DisplayStartMessage() // Displaying the starting message
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine($"{_description}");
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }
    public void GetReady()
    {
        Console.WriteLine("Get Ready...");
        PauseShowingSpinner();
    }
    public void DisplayEndMessage() // Displaying the ending message
    {
        Console.WriteLine();
        Console.WriteLine("\nWell Done!!");
        PauseShowingSpinner();
        Console.WriteLine($"\nYou have completed another {_duration} seconds of {_name}.");
        PauseShowingSpinner();
    }

    public void PauseShowingSpinner() // Pausing while showing a spinner
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        foreach (string a in animationStrings)
        {
            Console.Write(a);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void PauseShowingCntTimer() // Pausing while showing a countdown timer
    {
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    /*
    Displaying the starting message
    Displaying the ending message
    Pausing while showing a spinner
    Pausing while showing a countdown timer */


}