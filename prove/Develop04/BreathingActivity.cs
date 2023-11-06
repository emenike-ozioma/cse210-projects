public class BreathingActivity : Activity
{
    // Constructor
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking through your breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    // Method
    public void BreatheInOut()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write($"\nBreathe in...");
            PauseShowingCntTimer();
            Console.Write("\nNow breathe out...");
            PauseShowingCntTimer();
        }
    }
}