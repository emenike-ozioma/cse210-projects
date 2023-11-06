using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    // Attribute
    private List<string> _promptList = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questionList = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Constructor
    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspect of your life.";
    }

    // Method 
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_promptList.Count);
        return _promptList[index];
    }
    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questionList.Count);
        return _questionList[index];
    }
    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine($" --- {prompt} ---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

    }
    public void DisplayQuestions()
    {
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        PauseShowingCntTimer();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"\n> {question}");
            PauseShowingSpinner();
        } 
    }
}