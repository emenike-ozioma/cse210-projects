public class ListingActivity : Activity
{
    // Attribute
    private List<string> _promptList = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Constructor
    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    // Method
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_promptList.Count);
        return _promptList[index];
    }
    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses you can to the following prompt: ");
        Console.WriteLine($" --- {prompt} --- ");
    }
    public void AnswerPromptQuestion()
    {
        Console.Write("You may begin in: ");
        PauseShowingCntTimer();

        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        int responseCount = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();

            responseCount++;
        }

        Console.WriteLine($"You listed {responseCount} items!");
    }
}