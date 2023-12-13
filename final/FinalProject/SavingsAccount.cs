public class SavingsAccount : Account
{
    private double _interestRate;
    public SavingsAccount(int accountNumber, string accountHolderName)
        : base(accountNumber, accountHolderName)
    {
        _interestRate = 0.02;
    }

    // Overrides the Withdraw method to include interest calculation
    public override void Withdraw(double amount)
    {
        if (_accountBalance >= amount)
        {
            _accountBalance -= amount;
            Transaction transaction = new Transaction(Guid.NewGuid().ToString().Substring(0,12).ToUpper(), Transaction.TransactionType.Withdraw, amount);
            base.AddTransaction(transaction);
        }
        else
        {
            Console.WriteLine("Insufficient Funds!");
        }
    }

    // Overrides the Deposit method to include interest calculation
    public override void Deposit(double amount)
    {
        _accountBalance += amount + (amount * _interestRate);
        Transaction transaction = new Transaction(Guid.NewGuid().ToString().Substring(0,12).ToUpper(), Transaction.TransactionType.Deposit, amount);
        base.AddTransaction(transaction);
    }
    
    // Overrides the DisplayAccountInfo method for specific information
    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();
        Console.WriteLine($"Interest Rate: {_interestRate:P}"); // "_interestRate:P" Interest rate value is formatted as a percentage in the output e.g 0.05 for 5%
    }
}