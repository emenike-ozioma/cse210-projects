public class CheckingAccount : Account
{
    private double _overdraftLimit; // Represents the maximum negative balance allowed
    
    // Constructor
    public CheckingAccount() 
        : base()
    {
        _overdraftLimit = 0;
    }

    // Overrides the Withdraw method to include overdraft limit checking
    public override void Withdraw(double amount)
    {
        if (_accountBalance - amount >= _overdraftLimit)
        {
            _accountBalance -= amount;
        }
        else
        {
            Console.WriteLine("Withdrawal exceeds overdraft limit!");
        }
    }

    // Overrides the Deposit method for specific behavior (no interest in CheckingAccount)
    public override void Deposit(double amount)
    {
        _accountBalance += amount;
    }
    
    // Overrides the DisplayAccountInfo method for specific information
    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();
        Console.WriteLine($"Overdraft Limit: {_overdraftLimit:C}"); // "_overdraftLimit:C" Formats the value of OverdraftLimit as a currency string e.g 500 for $500
    }
}