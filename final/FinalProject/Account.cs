public abstract class Account
{
    // Attributes
    private int _accountNumber;
    private string _accountHolderName;
    protected double _accountBalance;
    private TransactionHistory _transactionHistory;

    // Constructor initializes bank account properties
    public Account(int accountNumber, string accountHolderName)
    {
        _accountNumber = accountNumber;
        _accountHolderName = accountHolderName;
        _accountBalance = 0;
        _transactionHistory = new TransactionHistory();
    }

    // Getters and Setters to access private member variables
    public int GetAccountNumber()
    {
        return _accountNumber;
    }
    public void SetAccountNumber(int accountNumber)
    {
        _accountNumber = accountNumber;
    }
    public string GetAccountHolderName()
    {
        return _accountHolderName;
    }
    public void SetAccountHolderName(string accountHolderName)
    {
        _accountHolderName = accountHolderName;
    }
    public double GetAccountBalance()
    {
        return _accountBalance;
    }
    public void SetAccountBalance(double accountBalance)
    {
        _accountBalance = accountBalance;
    }

    // Abstract method for withdrawing money
    public abstract void Withdraw(double amount);

    // Abstract method for depositing money
    public abstract void Deposit(double amount);

    // Virtual method to display account information
    public virtual void DisplayAccountInfo()
    {
        Console.WriteLine($"Account Number: {_accountNumber}");
        Console.WriteLine($"Account Holder: {_accountHolderName}");
        Console.WriteLine($"Balance: {_accountBalance:C}");
        Console.WriteLine("\nTransaction History: ");
        _transactionHistory.DisplayTransactionHistory();
    }
    public void AddTransaction(Transaction transaction)
    {
        _transactionHistory.AddTransaction(transaction);
    }
}