using System;
using System.Collections.Generic;
using System.IO;

public class GoalTracker
{
    private List<Goal> _goalList;
    private int _totalPoints;

    public GoalTracker()
    {
        _goalList = new List<Goal>();
        _totalPoints = 0;
    }

    public List<Goal> GetGoalList()
    {
        return _goalList;
    }
    public void SetGoalList(List<Goal> goalList)
    {
        _goalList = goalList;
    }
    public int GetTotalPoints()
    {
        return _totalPoints;
    }
    public void SetTotalPoints(int totalPoint)
    {
        _totalPoints = totalPoint;
    }

    // Method to save Goal to a file.
    public void SaveToFile()
    {
        Console.Write("What is the filename for the goal file? ");
        string userFileName = Console.ReadLine();
        Console.Write($"Saving '{userFileName}' To File... ");
        PauseShowingSpinner();

        // Create a StreamWriter to write data to the specified file.
        using(StreamWriter writer = new StreamWriter(userFileName))
        {
            writer.WriteLine($"{_totalPoints}");
            // Iterate through each entry and write its properties to the file.
            foreach (Goal goal in _goalList)
            {
                writer.WriteLine($"{goal.SavedGoalRepresentation()}");
            }
        }

        // Display a message indicating that the Goal has been saved to the file.
        Console.WriteLine("Goal saved to file.");
    }

    // Method to load Goal from a file.
    public void LoadFromFile()
    {
        Console.WriteLine("What is the file name of the goal file? ");
        string userFileName = Console.ReadLine();
        Console.Write($"Reading from '{userFileName}'... ");
        PauseShowingSpinner();

        if (File.Exists(userFileName))
        {
            // Clear the current list of goals.
            _goalList.Clear();

            // Read all lines from file and store it to a list of strings.
            string[] readLines = System.IO.File.ReadAllLines(userFileName);

            // Method to get the totalPoints and goals saved in the file.
            foreach (string line in readLines)
            {
                // Checks if line can be parsed to an integer
                if (int.TryParse(line, out int point))
                {
                    // If successful, the parsed integer value is stored in the _totalPoints variable.
                    _totalPoints = point;
                }
                else
                {
                    // Split the line into two parts using a column as the delimiter.
                    string[] parts = line.Split(": ");

                    if (parts.Length >= 2)
                    {
                        string goalType = parts[0].Trim();
                        string[] goalData = parts[1].Split("~");

                        switch(goalType)
                        {
                            case "SimpleGoal":
                                if (goalData.Length == 4)
                                {
                                    SimpleGoal sGoal = new SimpleGoal();
                                    sGoal.SetName(goalData[0].Trim());
                                    sGoal.SetDescription(goalData[1].Trim());
                                    sGoal.SetPoint(int.Parse(goalData[2]));
                                    sGoal.SetCompleted(bool.Parse(goalData[3]));

                                    _goalList.Add(sGoal);
                                }
                                break;

                            case "EternalGoal":
                                if (goalData.Length == 3)
                                {
                                    EternalGoal eGoal = new EternalGoal();
                                    eGoal.SetName(goalData[0].Trim());
                                    eGoal.SetDescription(goalData[1].Trim());
                                    eGoal.SetPoint(int.Parse(goalData[2]));

                                    _goalList.Add(eGoal);
                                }
                                break;

                            case "ChecklistGoal":
                                if (goalData.Length == 6)
                                {
                                    ChecklistGoal cGoal = new ChecklistGoal();
                                    cGoal.SetName(goalData[0].Trim());
                                    cGoal.SetDescription(goalData[1].Trim());
                                    cGoal.SetPoint(int.Parse(goalData[2]));
                                    cGoal.SetBonusAmount(int.Parse(goalData[3]));
                                    cGoal.SetTimesAccomplished(int.Parse(goalData[4]));
                                    cGoal.SetTimesCheckedOff(int.Parse(goalData[5]));

                                    _goalList.Add(cGoal);
                                }
                                break;
                        }
                    }
                
                }
            }

            // Display a message indicating that the user file has been loaded.
            Console.WriteLine($"'{userFileName}' Loading Complete.");
            Console.WriteLine("\nNow List Your Loaded File To View Content!");

        }
        else{
            Console.WriteLine($"Error loading goals from file: 'FileNotFound' ");
        }
    }

    // This Exceeds the Code Requirement
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
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
    }
}