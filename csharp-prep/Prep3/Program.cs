using System;

class Program
{
    static void Main(string[] args)
    {   
        string response = "yes";

        while (response == "yes")
        {
            string guessed;
            int track = 0;
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            do
            {
                Console.Write("What is your guess? ");
                string answer = Console.ReadLine();
                int guess = int.Parse(answer);

                if (guess > magicNumber)
                {
                    guessed = "Lower";
                }
                else if (guess < magicNumber)
                {
                    guessed = "Higher";
                }
                else
                {
                    guessed = "You guessed it!";
                }

                Console.WriteLine(guessed);
                track ++;

            } while (guessed != "You guessed it!");

            Console.WriteLine($"You guessed {track} times.");

            Console.Write("Do you want to play again? ");
            response = Console.ReadLine();
        }
    }
}