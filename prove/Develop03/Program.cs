using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture _scripture = new Scripture(2, "Corinthians", 5, 1, 3, "1. For we know that if our earthly house of this tabernacle were dissolved, we have a building of God, an house not made with hands, eternal in the heavens.\n2. For in this we groan, earnestly desiring to be clothed upon with our house which is from heaven: \n3. If so be that being clothed shall not be found naked.");

        Console.Clear();
        _scripture.RenderedDisplay();

        Console.WriteLine("\n\nPlease press 'enter' key to continue or type 'quit' to finish:");
        while (true)
        {
            string user_input = Console.ReadLine();
            if (user_input.ToLower() == "quit")
            {
                break;
            }
            if (!_scripture.HideWords())
            {
                break;
            }

            Console.Clear();
            _scripture.RenderedDisplay();
            Console.WriteLine("\n\nPlease press 'enter' key to continue or type 'quit' to finish:");
        }
    }
}
// The program exceeds the core requirements by displaying a scripture with first epistle and second epistle and gave it a member variable position;