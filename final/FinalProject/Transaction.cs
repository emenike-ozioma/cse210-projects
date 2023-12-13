using System.Transactions;

public class Transaction
{
    private string _transactionId;
    private DateTime _transactionDate;
    private TransactionType _transactionType;
    private double _amount;

    public Transaction(string transactionId, TransactionType transactionType, double amount)
    {
        _transactionId = transactionId;
        _transactionDate = DateTime.Now;
        _transactionType = transactionType;
        _amount = amount;
    }

    public enum TransactionType
    {
        Withdraw,
        Deposit,
        Unknown
    }
    public override string ToString()
    {
        return $"transactionID - {_transactionId} \n{_transactionDate} - {_transactionType}: {_amount:C}";
    }
}