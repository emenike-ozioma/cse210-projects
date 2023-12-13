using System;
using System.Text.Json.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Banking System!");
        Bank bank = new Bank();

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1.   Create Customer");
            Console.WriteLine("2.   Open Account");
            Console.WriteLine("3.   Make Transaction");
            Console.WriteLine("4    Display Customer Information");
            Console.WriteLine("5    Exit");

            Console.Write("Enter your choice (1-5): ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch(choice)
            {
                case 1:
                    // Code to create customer
                    Console.Write("Enter customer first name: ");
                    string firstName = Console.ReadLine();

                    Console.Write("Enter customer last name: ");
                    string lastName = Console.ReadLine();

                    if (firstName == "" || lastName == "")
                    {
                        Console.WriteLine("Please enter first name and last name");
                    }
                    else 
                    {
                        Customer customer = new Customer(Guid.NewGuid().ToString().Substring(0,4).ToUpper(), firstName, lastName);
                        bank.AddCustomers(customer);

                        Console.WriteLine($"\nCustomer {firstName} {lastName} created with ID: {customer.GetCustomerId()}");
                        Console.WriteLine("Please record your CustomerID, it will be used to indentify you!");
                    }
                    break;
                
                case 2:
                    // Code to open account
                    Console.Write("Enter customer ID: ");
                    string customerId = Console.ReadLine();

                    Customer customer1 = bank.FindCustomerById(customerId);

                    if (customer1 == null)
                    {
                        Console.WriteLine("Customer not found. Please enter a valid customer ID");
                        Console.WriteLine("If you dont have a customerID, create customer to get an ID");
                    }
                    else 
                    {
                        Console.WriteLine($"Customer: {customer1.GetFirstName()} {customer1.GetLastName()}");
                        Console.WriteLine("\nSelect an account type:");
                        Console.WriteLine("1.   Savings Account");
                        Console.WriteLine("2.   Checking Account");
                        Console.WriteLine("3.   Fixed Deposit Account");

                        Console.Write("Enter your choice (1-3): ");
                        int response = int.Parse(Console.ReadLine());
                        switch (response)
                        {
                            case 1:
                                SavingsAccount savingsAccount = new SavingsAccount(bank.GenerateAccountNumber(), $"{customer1.GetFirstName()} {customer1.GetLastName()}");

                                customer1.AddAccount(savingsAccount);
                                Console.WriteLine($"Savings Account opened for {customer1.GetFirstName()} {customer1.GetLastName()} with account number {savingsAccount.GetAccountNumber()}");
                                break;

                            case 2:
                                Console.Write("Enter overdraft limit: ");
                                if (double.TryParse(Console.ReadLine(), out double overdraftLimit))
                                {
                                    CheckingAccount checkingAccount = new CheckingAccount(bank.GenerateAccountNumber(), $"{customer1.GetFirstName()} {customer1.GetLastName()}", overdraftLimit);

                                    customer1.AddAccount(checkingAccount);
                                    Console.WriteLine($"Checking Account opened for {customer1.GetFirstName()} {customer1.GetLastName()} with account number {checkingAccount.GetAccountNumber()}");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid overdraft limit. Please enter a valid number");
                                }
                                break;

                            case 3:
                                Console.Write("\nEnter maturity date (e.g., yyy-mm-dd): ");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime maturityDate))
                                {
                                    FixedDepositAccount fixedDepositAccount = new FixedDepositAccount(bank.GenerateAccountNumber(), $"{customer1.GetFirstName()} {customer1.GetLastName()}", maturityDate);
                                    customer1.AddAccount(fixedDepositAccount);
                                    Console.WriteLine($"Fixed Deposit Account opened for {customer1.GetFirstName()} {customer1.GetLastName()} with account number {fixedDepositAccount.GetAccountNumber()}");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid maturity date. Please enter a valid date in the format yyyy-mm-dd.");
                                }
                                break;

                            default:
                                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                                break;
                        }
                    }
                    break;
                
                case 3:
                    // Code to make transaction
                    Console.Write("Enter customer ID: ");
                    string customerID = Console.ReadLine();

                    Customer customer2 = bank.FindCustomerById(customerID);

                    if (customer2 == null)
                    {
                        Console.WriteLine("Customer not found. Please enter a valid customer ID");
                    }
                    else
                    {
                        Console.WriteLine($"Customer: {customer2.GetFirstName()} {customer2.GetLastName()}");

                        Console.Write("\nEnter account number: ");
                        int accountNumber = int.Parse(Console.ReadLine());
                        
                        Account account = customer2.FindAccountByNumber(accountNumber);
                        if (account == null)
                        {
                            Console.WriteLine("Account not found. Please enter a valid account number");
                        }
                        else
                        {
                            Console.WriteLine($"Account Type: {account.GetType().Name}");
                            Console.Write("\nSelect a transaction type (1. Withdraw, 2. Deposit): ");
                            if (int.TryParse(Console.ReadLine(), out int transactionTypeChoice))
                            {
                                Transaction.TransactionType transactionType = Transaction.TransactionType.Unknown;

                                // Validate and set the transaction type
                                if(transactionTypeChoice == 1)
                                {
                                    transactionType = Transaction.TransactionType.Withdraw;
                                    Console.Write("\nEnter transaction amount: ");
                                    if (double.TryParse(Console.ReadLine(), out double transactionAmount))
                                    {
                                        TransactionProcessor withdraw = new TransactionProcessor();
                                        withdraw.ProcessTransaction(account, transactionType, transactionAmount);

                                        Console.WriteLine("\nTransaction Completed. Updated Account Information");
                                        account.DisplayAccountInfo();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid transaction amount. Please enter a valid amount");
                                    }
                                }
                                else if (transactionTypeChoice == 2)
                                {
                                    transactionType = Transaction.TransactionType.Deposit;
                                    Console.Write("\nEnter transaction amount: ");
                                    if (double.TryParse(Console.ReadLine(), out double transactionAmount))
                                    {
                                        TransactionProcessor deposit = new TransactionProcessor();
                                        deposit.ProcessTransaction(account, transactionType, transactionAmount);

                                        Console.WriteLine("\nTransaction Completed. Updated Account Information");
                                        account.DisplayAccountInfo();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid transaction amount. Please enter a valid amount");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid transaction type. Please enter 1 or 2 for transaction type");
                                }
                            }
                        }    
                    }
                    break;

                case 4: 
                    // Code to display customer information
                    Console.Write("Enter customer ID: ");
                    string customerIdForInfo = Console.ReadLine();

                    Customer customer3 = bank.FindCustomerById(customerIdForInfo);
                    if (customer3 == null)
                    {
                        Console.WriteLine("Customer not found. Please enter a valid customer ID.");
                    }
                    else
                    {
                        Console.WriteLine($"Customer: {customer3.GetFirstName()} {customer3.GetLastName()}");
                        Console.WriteLine("\nAccounts: ");

                        foreach (Account account in customer3.GetAccounts())
                        {
                            Console.WriteLine($"\nAccount Type: {account.GetType().Name}, Account Number: {account.GetAccountNumber()}");
                            account.DisplayAccountInfo();
                            Console.WriteLine();
                        }
                    }
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please choose from the options (1-4) or choose 5 to Quit");
                    break;
            }
        }
    }
}