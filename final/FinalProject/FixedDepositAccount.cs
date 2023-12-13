public class FixedDepositAccount : Account
{
    private double _interestRate;
    private DateTime _maturityDate;

    public FixedDepositAccount(int accountNumber, string accountHolderName, DateTime maturityDate)
        : base(accountNumber, accountHolderName)
    {
        _interestRate = 0.05;
        _maturityDate = maturityDate;
    }
    public override void Withdraw(double amount)
    {
        if (DateTime.Now < _maturityDate)
        {
            Console.WriteLine("Cannot withdraw from a fixed deposit account before maturity date.");
        }
        else
        {
            if (_accountBalance >= amount)
            {
                _accountBalance -= amount;
                Transaction transaction = new Transaction(Guid.NewGuid().ToString().Substring(0,12).ToUpper(), Transaction.TransactionType.Withdraw, amount);
                base.AddTransaction(transaction);
            }
            else
            {
                Console.WriteLine("Cannot withdraw more than balance!");
                Console.WriteLine($"Your Balance is: {_accountBalance:C}");
            }
        }
    }
    public override void Deposit(double amount)
    {
        if (DateTime.Now > _maturityDate)
        {
            Console.WriteLine("Cannot deposit into a fixed deposit account before start date.");
        }
        else
        {
            _accountBalance += amount + (amount * _interestRate);
            Transaction transaction = new Transaction(Guid.NewGuid().ToString().Substring(0,12).ToUpper(), Transaction.TransactionType.Deposit, amount);
            base.AddTransaction(transaction);
        }
    }
    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();
        Console.WriteLine($"Interest Rate: {_interestRate:P}");
        Console.WriteLine($"Maturity Date: {_maturityDate:d}");
    }
}