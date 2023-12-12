public class SavingsAccount : Account
{
    private double _interestRate;
    public SavingsAccount()
        : base()
    {
        _interestRate = 0;
    }

    // Overrides the Withdraw method to include interest calculation
    public override void Withdraw(double amount)
    {
        if (_accountBalance >= amount)
        {
            _accountBalance -= amount;
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
    }
    
    // Overrides the DisplayAccountInfo method for specific information
    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();
        Console.WriteLine($"Interest Rate: {_interestRate:P}"); // "_interestRate:P" Interest rate value is formatted as a percentage in the output e.g 0.05 for 5%
    }
}