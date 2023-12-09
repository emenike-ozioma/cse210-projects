using System;

public class ChecklistGoal : Goal
{
    private int _timesAccomplished;
    private int _bonusAmount;
    private int _timesCheckedOff;

    public ChecklistGoal()
        : base()
    {
        _timesAccomplished = 0;
        _bonusAmount = 0;
        _timesCheckedOff = 0;
    }

    public int GetTimesAccomplished()
    {
        return _timesAccomplished;
    }
    public void SetTimesAccomplished(int timesAccomplished)
    {
        _timesAccomplished = timesAccomplished;
    }

    public int GetBonusAmount()
    {
        return _bonusAmount;
    }
    public void SetBonusAmount(int bonusAmount)
    {
        _bonusAmount = bonusAmount;
    }

    public int GetTimesCheckedOff()
    {
        return _timesCheckedOff;
    }
    public void SetTimesCheckedOff(int timesCheckedOff)
    {
        _timesCheckedOff = timesCheckedOff;
    }

    public override void DisplayPrompt()
    {
        base.DisplayPrompt();
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        _timesAccomplished = int.Parse(Console.ReadLine());

        Console.Write("What is the bonus for accomplishing it that many times? ");
        _bonusAmount = int.Parse(Console.ReadLine());
    }

    public override string GetList()
    {
        if (_timesCheckedOff >= _timesAccomplished)
        {
            return $". [x] {_name} ({_description}) -- Currently completed: {_timesCheckedOff}/{_timesAccomplished}";
        }
        else {
            return $". [ ] {_name} ({_description}) -- Currently completed: {_timesCheckedOff}/{_timesAccomplished}";
        }
    }

    public override string SavedGoalRepresentation()
    {
        return $"ChecklistGoal: {_name}~{_description}~{_point}~{_bonusAmount}~{_timesAccomplished}~{_timesCheckedOff}";
    }

    public override int RecordEvent()
    {
        _timesCheckedOff += 1;
        
        if (_timesCheckedOff == _timesAccomplished)
        {
            _point +=_bonusAmount;

            Console.WriteLine($"Congratulations! You have earned {_point} points!");
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {_point} points!");
        }
        return _point;
    }
}