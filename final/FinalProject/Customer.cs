public class Customer
{
    private string _customerId;
    private string _firstName;
    private string _lastName;
    private List<Account> _accounts;

    // Constructor initializes customer properties and the list of accounts
    public Customer(string customerId, string firstName, string lastName)
    {
        _customerId = customerId;
        _firstName = firstName;
        _lastName = lastName;
        _accounts = new List<Account>();
    }

    // Getters and Setters to access private member variables
    public string GetCustomerId()
    {
        return _customerId;
    }
    public void SetcustomerId(string customerId)
    {
        _customerId = customerId;
    }
    public string GetFirstName()
    {
        return _firstName;
    }
    public void SetFirstName(string firstName)
    {
        _firstName = firstName;
    }
    public string GetLastName()
    {
        return _lastName;
    }
    public void SetLastName(string lastName)
    {
        _lastName = lastName;
    }
    public List<Account> GetAccounts()
    {
        return _accounts;
    }

    // Method to add a bank account to the customers list
    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }
    // Method to display customers information
    public void DisplayCustomerInfo()
    {
        Console.WriteLine($"CustomerID: {_customerId}");
        Console.WriteLine($"Name: {_firstName} {_lastName}");
        Console.WriteLine("Accounts:");

        foreach (Account account in _accounts)
        {
            Console.WriteLine($"    Account Number: {account.GetAccountNumber()}");
            Console.WriteLine($"    Account Holder: {account.GetAccountHolderName()}");
            Console.WriteLine($"    Balance: {account.GetAccountBalance():C}");
            Console.WriteLine();
        }
    }
    // Method to find a bank account by account number 
    public Account FindAccountByNumber(int accountNumber)
    {
        // Finds an returns an Account object from the _accounts
        // list based on the provided accountNumber
        return _accounts.Find(a => a.GetAccountNumber() == accountNumber);
    }
}