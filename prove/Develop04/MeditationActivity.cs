public class MeditationActivity : Activity
{
    private List<string> _bodyParts = new List<string>
    {"Back", "Chest", "Feet", "Legs", "Shoulder", "Arms", "Hips", "Neck", "Head", "Hands"};

    public MeditationActivity()
    {
        _name = "Meditation Activity";
        _description = "This activity will guide you through different body parts, allowing you to focus on sensations and relax";
    }
    public string GetRandomBodyPart()
    {
        Random random = new Random();
        int index = random.Next(_bodyParts.Count);
        return _bodyParts[index];
    }
    public void DisplayMeditation()
    {
        Console.WriteLine("Find a confortable and quiet place to sit or lie down.");
        Console.WriteLine("Close your eyes and bring your attention to your body.");
        PauseShowingSpinner();

        Console.Write("Body scan meditation begins in: ");
        PauseShowingCntTimer();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string bodyPart = GetRandomBodyPart();

            Console.Write($"\nFocus on your {bodyPart}. Breathe in slowly and deeply, then exhale fully.");
            PauseShowingSpinner();

            Console.WriteLine($"\nNotice any sensations or tension in your {bodyPart}");
            PauseShowingCntTimer();

            Console.Write("As you inhale, imagine breathing relaxation into this area. As you exhale, let go of any tension.");
            PauseShowingSpinner();

            Console.WriteLine();
            
            Console.WriteLine("\nPress Enter to move to the next body part.");
            Console.ReadLine();
        }
    }
}