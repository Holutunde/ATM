public class RegisteredAccounts
{
    private List<Account> accounts = new List<Account>();

    public RegisteredAccounts()
    {
        accounts.Add(new Account("Olutunde Sokunbi", 1234567890, 1234, 4567.45));
        accounts.Add(new Account("Tayo Gbotemi", 678912345, 3456, 10));
        accounts.Add(new Account("Shoremi Bankole", 345678912, 7890, 89.45));
        accounts.Add(new Account("Baba Tunde", 789078906, 4567, 2000));
    }

    public List<Account> GetAccounts()
    {
        return accounts;
    }
}
