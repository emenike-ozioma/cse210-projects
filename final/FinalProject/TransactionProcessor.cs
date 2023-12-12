using static Transaction;

public class TransactionProcessor
{
    public void ProcessTransaction(Account account, TransactionType transactionType, double amount)
    {
        switch (transactionType)
        {
            case TransactionType.Withdraw:
                account.Withdraw(amount);
                break;

            case TransactionType.Deposit:
                account.Deposit(amount);
                break;
            
            default: 
                Console.WriteLine("Invalid Transaction Type");
                break;
        }
    }
}