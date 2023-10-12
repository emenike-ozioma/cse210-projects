using System;

public class Entry
{
    // Properties/Attributes:
    // Properties for Date, Prompt, and Response.
    public string _date;
    public string _prompt;
    public string _response;

    // Constructor for creating Entry objects with specified properties.
    public Entry(string prompt, string response, string dateTime)
    {
        _date = dateTime;
        _prompt = prompt;
        _response = response;
    }

    // Method/Behaviours:
    public string DisplayData()
    {
        return $"\nDate: {_date}\nPrompt: {_prompt}\nResponse: {_response}";    
    }
}