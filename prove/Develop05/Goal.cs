using System;
public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _point;

    public Goal()
    {
        _name = "unknown";
        _description = "undefined";
        _point = 0;
    }

    public string GetName()
    {
        return _name;
    }
    public void SetName(string name)
    {
        _name = name;
    }

    public string GetDescription()
    {
        return _description;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }

    public int GetPoint()
    {
        return _point;
    }
    public void SetPoint(int point)
    {
        _point = point;
    }

    public virtual void DisplayPrompt()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        _point = int.Parse(Console.ReadLine());
        
    }

    public abstract string GetList();
    public abstract string SavedGoalRepresentation();
    public abstract int RecordEvent();
}
