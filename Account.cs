public class Account
{
    public string Name { get; set; }
    public long AccountNumber { get; set; }
    public int Pin { get; set; }
    public double Balance { get; set; }

    public Account(string name, long accountNumber, int pin, double balance)
    {
        Name = name;
        AccountNumber = accountNumber;
        Pin = pin;
        Balance = balance;
    }
}
