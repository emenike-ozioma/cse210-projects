public class Transaction
{
    private string _transactionId;
    private DateTime _transactionDate;
    private TransactionType _transactionType;
    private double _amount;

    public Transaction()
    {
        _transactionId = "";
        _transactionDate = DateTime.Now;
        _transactionType = TransactionType.Unknown;
        _amount = 0;
    }

    public enum TransactionType
    {
        Withdraw,
        Deposit,
        Unknown
    }
}