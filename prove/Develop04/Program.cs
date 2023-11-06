using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Welcome to the Mindfulness Program!");

        while (true)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("    1. Start Breathing Activity");
            Console.WriteLine("    2. Start Reflecting Activity");
            Console.WriteLine("    3. Start Listing Activity");
            Console.WriteLine("    4. Start Meditating Activity");
            Console.WriteLine("    5. Quit");

            Console.Write("Select a choice from the menu: ");
            int userInput = int.Parse(Console.ReadLine());

            switch(userInput)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.DisplayStartMessage();
                    breathingActivity.GetReady();

                    breathingActivity.BreatheInOut();

                    breathingActivity.DisplayEndMessage();
                    break;

                case 2:
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.DisplayStartMessage();
                    reflectingActivity.GetReady();

                    reflectingActivity.DisplayPrompt();
                    reflectingActivity.DisplayQuestions();

                    reflectingActivity.DisplayEndMessage();
                    break;

                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.DisplayStartMessage();
                    listingActivity.GetReady();

                    listingActivity.DisplayPrompt();
                    listingActivity.AnswerPromptQuestion();

                    listingActivity.DisplayEndMessage();
                    break;

                case 4:
                    MeditationActivity meditationActivity = new MeditationActivity();
                    meditationActivity.DisplayStartMessage();
                    meditationActivity.GetReady();

                    meditationActivity.DisplayMeditation();

                    meditationActivity.DisplayEndMessage();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please choose from the options (1-5)");
                    break;
            }
        
        }
    }
}

//EXCEEDING REQUIREMENTS: ADDED ANOTHER KIND OF ACTIVITY.