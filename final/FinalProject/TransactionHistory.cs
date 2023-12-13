public class TransactionHistory
{
    private List<Transaction> _transactions;

    public TransactionHistory()
    {
        _transactions = new List<Transaction>();
    }

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    public void DisplayTransactionHistory()
    {
        foreach (var transaction in _transactions)
        {
            Console.WriteLine(transaction);
        }
    }
}