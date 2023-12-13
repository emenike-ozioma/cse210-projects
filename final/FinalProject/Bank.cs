// Bank class manages customers and transactions
public class Bank
{
    // Attribute
    private List<Customer> _customers;

    // Constructor initializes the list of customers
    public Bank()
    {
        _customers = new List<Customer>();
    }

    // Method to add a customer to the bank
    public void AddCustomers(Customer customer)
    {
        _customers.Add(customer);
    }

    // Method to display information for all customers
    public void DisplayAllCustomers()
    {
        Console.WriteLine("Customer Information for All Customers:");

        foreach (Customer customer in _customers)
        {
            customer.DisplayCustomerInfo();
            Console.WriteLine("-------------------------");
        }
    }
    // Method to find a customer by ID
    public Customer FindCustomerById(string customerId)
    {
        return _customers.Find(c => c.GetCustomerId() == customerId);
    }
    public int GenerateAccountNumber()
    {
        string _stringNumbers = new string(Guid.NewGuid().ToString("N").Substring(0,8).Where(char.IsDigit).ToArray());
        return int.Parse(_stringNumbers);
    }
}