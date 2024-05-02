public class RegisteredAccounts
{
    public static List<Account> GetAccounts()
    {
        return new List<Account>
        {
            new Account { Name = "Olutunde Sokunbi", AccountNumber = 1234567890, Pin = 1234, Balance = 4567.45 },
            new Account { Name = "Tayo Gbotemi", AccountNumber = 678912345, Pin = 3456, Balance = 10 },
            new Account { Name = "Shoremi Bankole", AccountNumber = 345678912, Pin = 7890, Balance = 89.45 },
            new Account { Name = "Baba Tunde", AccountNumber = 789078906, Pin = 4567, Balance = 2000 },
            new Account { Name = "Adebayo Oladipo", AccountNumber = 456789012, Pin = 9876, Balance = 300 },
            new Account { Name = "Kehinde Ola", AccountNumber = 987654321, Pin = 1357, Balance = 10000 },
            new Account { Name = "Femi Ogunleye", AccountNumber = 321654987, Pin = 2468, Balance = 7500 },
            new Account { Name = "Seun Ade", AccountNumber = 654789123, Pin = 3690, Balance = 15000 },
            new Account { Name = "Chinedu Eze", AccountNumber = 951753456, Pin = 1593, Balance = 5000 },
            new Account { Name = "Tope Alabi", AccountNumber = 147258369, Pin = 3579, Balance = 800 }
        };
    }
}

