using System;
public class EternalGoal : Goal
{
    public override string GetList()
    {
        return $". [ ] {_name} ({_description})";
    }
    public override string SavedGoalRepresentation()
    {
        return $"EternalGoal: {_name}~{_description}~{_point}";
    }
    public override int RecordEvent()
    {
        Console.WriteLine($"Congratulations! You have earned {_point} points!");
        return _point;
    }
}