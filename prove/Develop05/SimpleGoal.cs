using System;
public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal()
        : base()
    {
        _isCompleted = false;
    }

    public bool GetCompleted()
    {
        return _isCompleted;
    }
    public void SetCompleted(bool isCompleted)
    {
        _isCompleted = isCompleted;
    }

    public override string GetList()
    {
        if (_isCompleted == true)
        {
            return $". [x] {_name} ({_description})";
        }
        else{
            return $". [ ] {_name} ({_description})";
        }
    }

    public override string SavedGoalRepresentation()
    {
        return $"SimpleGoal: {_name}~{_description}~{_point}~{_isCompleted}";
    }
    
    public override int RecordEvent()
    {
        _isCompleted = true;
        Console.WriteLine($"Congratulations! You have earned {_point} points!");
        return _point;
    }
}