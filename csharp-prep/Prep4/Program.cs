using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int digit;
        List<int> numbers = new List<int>();
        int sum = 0;
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter a number: ");
            digit = int.Parse(Console.ReadLine());
            if (digit != 0)
            {
                numbers.Add(digit);
            }

        } while(digit != 0);

        foreach (int number in numbers)
        {
            sum += number;
        }

        float average = ((float) sum) / numbers.Count;
        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}