public class Account
{
    public string Name { get; set; }
    public int AccountNumber { get; set; }
    public int Pin { get; set; }
    public double Balance { get; set; }

    public Account(string name, int accountNum, int atmPin, double balance)
    {
        Name = name;
        AccountNumber = accountNum;
        Pin = atmPin;
        Balance = balance;
    }
}
