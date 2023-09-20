using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");

        // for loop(python for x in range) 
        // counting from 2 to 20 by two's:
        for (int i = 2; i <= 20; i = i + 2 )
        {
            Console.WriteLine(i);
        }
        
        // get random number
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);
    }
}