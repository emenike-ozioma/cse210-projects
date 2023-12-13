public class CheckingAccount : Account
{
    private double _overdraftLimit; // Represents the maximum negative balance allowed
    
    // Constructor
    public CheckingAccount(int accountNumber, string accountHolderName, double overdraftLimit) 
        : base(accountNumber, accountHolderName)
    {
        _overdraftLimit = overdraftLimit;
    }

    // Overrides the Withdraw method to include overdraft limit checking
    public override void Withdraw(double amount)
    {
        if (_accountBalance - amount >= _overdraftLimit)
        {
            _accountBalance -= amount;
            Transaction transaction = new Transaction(Guid.NewGuid().ToString().Substring(0,12).ToUpper(), Transaction.TransactionType.Withdraw, amount);
            base.AddTransaction(transaction);
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
        Transaction transaction = new Transaction(Guid.NewGuid().ToString().Substring(0,12).ToUpper(), Transaction.TransactionType.Deposit, amount);
        base.AddTransaction(transaction);
    }
    
    // Overrides the DisplayAccountInfo method for specific information
    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();
        Console.WriteLine($"Overdraft Limit: {_overdraftLimit:C}"); // "_overdraftLimit:C" Formats the value of OverdraftLimit as a currency string e.g 500 for $500
    }
}