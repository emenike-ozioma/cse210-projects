using System;

public class PromptGenerator
{
    // List of prompts.
    public List<string> _promptList = new List<string>
    {
        "Who was the most interesting person i interacted with today? ",
        "What was the best part of my day? ",
        "How did i see the hand of the lord in my life today? ",
        "What was the strongest emotion i felt today? ",
        "If i had one thing i could do over today, what would it be? ",
        "What steps can you take today to move closer to your goals? ",
        "Share something that motivated you today and why? ",
        "How did you overcome a recent obstacle and what did you learn? ",
        "Reflect on a recent mistake and what you learned from it ? "
    };

    // Method to get a random prompt from the list.
    public string GetRandomPrompt()
    {
        // Create a new random number generator.
        Random random = new Random();

        // Generate a random index within the range of the prompts list.
        int index = random.Next(_promptList.Count);

        // Return the prompt at the randomly generated index.
        return _promptList[index];         
    }
}