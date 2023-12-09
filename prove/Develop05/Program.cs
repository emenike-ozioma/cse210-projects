using System;
// This assignment exceeds the requirements by adding a "Pause while showing a spinner" loading function when saving/loading a goal file.

class Program
{
    static void Main(string[] args)
    {
        int totalPoint = 0 ;
        List<Goal> goalList = new List<Goal>();

        while (true)
        {
            Console.WriteLine($"\nYou have {totalPoint} points.");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goal");
            Console.WriteLine("  4. Load Goal");
            Console.WriteLine("  5. Record Goal");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");
            int response = int.Parse(Console.ReadLine());

            switch(response)
            {
                case 1:
                    Console.WriteLine("The types of Goals are:");
                    Console.WriteLine("  1. Simple Goal");
                    Console.WriteLine("  2. Eternal Goal");
                    Console.WriteLine("  3. Checklist Goal");
                    Console.Write("Which type of goal would you like to create? ");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        SimpleGoal simpleGoal = new SimpleGoal();
                        simpleGoal.DisplayPrompt();
                        goalList.Add(simpleGoal);
                    }
                    else if (choice == 2)
                    {
                        EternalGoal eternalGoal = new EternalGoal();
                        eternalGoal.DisplayPrompt();
                        goalList.Add(eternalGoal);
                    }
                    else if (choice == 3)
                    {
                        ChecklistGoal checklistGoal = new ChecklistGoal();
                        checklistGoal.DisplayPrompt();
                        goalList.Add(checklistGoal);
                    }
                    else
                    {
                        Console.WriteLine("Please choose from the options 1-3");
                    }
                    break;

                case 2:
                    Console.WriteLine("The goals are:");
                    int numbering = 1;

                    foreach (Goal line in goalList)
                    {
                        Console.WriteLine($"{numbering}{line.GetList()}");
                        numbering++;
                    }
                    break;

                case 3:
                    GoalTracker save = new GoalTracker();
                    save.SetTotalPoints(totalPoint);
                    save.SetGoalList(goalList);
                    save.SaveToFile();
                    break;
                
                case 4:
                    GoalTracker load = new GoalTracker();
                    load.LoadFromFile();
                    totalPoint = load.GetTotalPoints();
                    goalList = load.GetGoalList();
                    break;
                
                case 5:
                    Console.WriteLine("The goals are:");
                    int position = 1;

                    foreach (Goal line in goalList)
                    {
                        Console.WriteLine($"{position}. {line.GetName()}");
                        position++;
                    }

                    Console.Write("Which goal did you accomplish? ");
                    int accomplishedGoal = int.Parse(Console.ReadLine());

                    if (accomplishedGoal >= 1 && accomplishedGoal <= goalList.Count)
                    {
                        // codes here to record the file
                        accomplishedGoal -= 1;
                        int newPoint = goalList[accomplishedGoal].RecordEvent();
                        totalPoint += newPoint;

                        Console.WriteLine($"You now have {totalPoint} points.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, please choose a number from the options");
                    }

                    break;

                case 6:
                    Environment.Exit(0);
                    break;
                
                default:
                    Console.WriteLine("Please choose from the options (1-5) or choose 6 to Quit");
                    break;
            }
        }
    }
}