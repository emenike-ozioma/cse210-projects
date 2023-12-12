public class FixedDepositAccount : Account
{
    private double _interestRate;
    private DateTime _maturityDate;
    private DateTime _startDate;

    public FixedDepositAccount()
        : base()
    {
        _interestRate = 0.05;
        _maturityDate = new DateTime();
        _startDate = new DateTime();
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
        if (DateTime.Now < _startDate)
        {
            Console.WriteLine("Cannot deposit into a fixed deposit account before start date.");
        }
        else
        {
            _accountBalance += amount + (amount * _interestRate);
            // AddTransaction(new Transaction(Guid.NewGuid().ToString(), TransactionType.Deposit, amount));
        }
    }
    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();
        Console.WriteLine($"Interest Rate: {_interestRate:P}");
        Console.WriteLine($"Start Date: {_startDate}");
        Console.WriteLine($"Maturity Date: {_maturityDate:D}");
    }
}