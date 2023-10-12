using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        Console.WriteLine($"\nHello {userName}!");

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int userInput;

        while (true)
        {
            // Display menu options.
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            // Get user input.
            Console.Write("What would you like to do? ");
            userInput = int.Parse(Console.ReadLine());
            
            switch (userInput)
            {
                // Case 1: Write a new entry
                case 1:
                    string prompt = promptGenerator.GetRandomPrompt();
                    journal.AddEntry(prompt);

                    // Exceeding requirement:
                    // display the total character count in journal entries.
                    journal.DisplayCharactersCount();
                    break;
                
                // Case 2: Display the journal.
                case 2:
                    journal.DisplayEntries();
                    break;
                
                // Case 3: Save the journal to file.
                case 3:
                    journal.SaveToFile();
                    break;
                
                // Case 4: Load the journal from a file.
                case 4:
                    journal.LoadFromFile();
                    break;

                // Case 5: Exit the program.
                case 5:
                    Environment.Exit(0);
                    break;
                
                // Default Case: Invalid input.
                default:
                    Console.WriteLine("Please choose from the options (1-5)");
                    break;
            }
        }
    }
}
// Exceeding Requirement:
// 1. Added a user name and greet the user.
// 2. Added a method that displays the total charater
//    count of the response in the journal entries.