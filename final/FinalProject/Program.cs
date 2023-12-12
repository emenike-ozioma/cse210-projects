using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Banking System!");

        while (true)
        {
            Console.WriteLine("\n Select an option:");
            Console.WriteLine("1.   Create Customer");
            Console.WriteLine("2.   Open Account");
            Console.WriteLine("3.   Make Transaction");
            Console.WriteLine("4    Display Customer Information");
            Console.WriteLine("5    Exit");

            Console.Write("Enter your choice (1-5)");
            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    break;
                
                case 2:
                    break;
                
                case 3:
                    break;

                case 4: 
                    break;

                case 5: 
                    break;
            }
        }
    }
}