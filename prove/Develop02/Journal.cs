using System;

public class Journal
{
    // List of Entry objects.
    public List<Entry> _entries = new List<Entry>();

    // Constructor:
    public Journal()
    {

    }

    // Methods:

    // Method to add a new Entry to the journal.
    public void AddEntry(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();
        DateTime theCurrentTime = DateTime.Now;
        string dateTime = theCurrentTime.ToShortDateString();

        // Add the provided entry object to the list of entries.
        _entries.Add(new Entry(prompt, response, dateTime));
    }

    // Method to Display all Entries in the journal.
    public void DisplayEntries()
    {
        // Iterate through each entry in the list and display
        // its properties using the entry display method.
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.DisplayData());
        }
    }

    // Method to save Journal Entries to a file.
    public void SaveToFile()
    {
        Console.WriteLine("What is the name of the file? ");
        string userFileName = Console.ReadLine();
        Console.WriteLine($"Saving '{userFileName}' To File...");

        // Create a StreamWriter to write data to the specified file.
        using(StreamWriter writer = new StreamWriter(userFileName))
        {
            // Iterate through each entry and write its properties to the file.
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}; {entry._prompt}; {entry._response}");
            }
        }

        // Display a message indicating that the journal has been saved to the file.
        Console.WriteLine("Journal saved to file.");
    }

    // Method to load Journal Entries from a file.
    public void LoadFromFile()
    {
        // load entry from a file
        Console.WriteLine("What is the name of the file? ");
        string userFileName = Console.ReadLine();
        Console.WriteLine($"Reading from '{userFileName}'...");

        // Clear the current list of entries.
        _entries.Clear();

        // Read all lines from file and store it to a list of strings.
        string[] readLines = System.IO.File.ReadAllLines(userFileName);

        // Read each line from the file
        foreach (string line in readLines)
        {
            // Split the line into parts using a semicolumn as the delimiter.
            string[] parts = line.Split(";");

            string dateTime = parts[0];
            string prompt = parts[1];
            string response = parts[2];

            // Create a new Entry object and add it to the list of entries.
            _entries.Add(new Entry(prompt, response, dateTime));
        }

        // Display a message indicating that the user file has been loaded.
        Console.WriteLine($"'{userFileName}' Loading Complete.");
        Console.WriteLine("\nNow Display Your Loaded File To View Content!");
    }

    // Method to calculate and display total character count of user response.
    public void DisplayCharactersCount()
    {
        int totalCharacters = 0;

        // calculate total character count from journal entries.
        foreach(Entry entry in _entries)
        {
            totalCharacters = entry._response.Length;
        }
        Console.WriteLine($"'{totalCharacters}' character(s)");
    }
}