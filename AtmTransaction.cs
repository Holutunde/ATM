

public class AtmTransaction : IAtmTransaction
{
    private Account account;

    public AtmTransaction(Account account)
    {
        this.account = account;
    }
    public static void CreateAccount(List<Account> accounts)
    {
        Console.Write("Please enter your full name (firstname lastname): ");
        string? username = Console.ReadLine();

        Console.Write("Enter your 4-digit PIN: ");
        int pin;
        while (!int.TryParse(Console.ReadLine(), out pin) || pin < 1000 || pin > 9999)
        {
            Messages.EnterValidPostivePin();
        }

        // Generate a random 10-digit account number
        Random random = new Random();
        long accountNumber = (long)(random.NextDouble() * 9000000000) + 1000000000;

        // Create the account and add it to the accounts list
        double newBalance = 100; 
        Account newAccount = new();

        newAccount.Name = username;
        newAccount.AccountNumber = accountNumber;
        newAccount.Pin = pin;
        newAccount.Balance = newBalance;

        accounts.Add(newAccount);

        // Account newAccount = new Account(username, accountNumber, pin, newBalance);
        // accounts.Add(newAccount);

        Messages.AccoutCreatedSuccessfully(accountNumber);
    }

    public void CheckBalance()
    {
        Messages.CheckBalanceMessage(account.Balance);
    }

    public void DepositMoney()
    {
        Console.Write("Enter the amount to deposit: ");

        double amount;
        while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Messages.EnterPostiveAmount();
        }

        account.Balance += amount;
        Messages.DepositSuccessful(amount, account.Balance);
    }

    public void WithdrawMoney()
    {
        Console.Write("Enter the amount to withdraw: ");

        double amount;
        while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Messages.EnterPostiveAmount();
        }

        if (amount > account.Balance)
        {
            Messages.InsufficientBalance();
            return;
        }

        account.Balance -= amount;
        Messages.WithdrawSuccessful(amount, account.Balance);
    }

    public void UpdatePin(List<Account> accounts)
    {
        bool pinUpdated = false;

        while (!pinUpdated)
        {
            Console.Write("Enter your current 4 digit PIN: ");
            int oldPin;
            if (!int.TryParse(Console.ReadLine(), out oldPin))
            {
                Messages.EnterValidPostivePin();
                continue;
            }

            var accountToUpdate = accounts.Find(account => account.Pin == oldPin);
            if (accountToUpdate != null)
            {
                Console.Write("Enter your new 4 digit PIN: ");
                int newPin;
                if (!int.TryParse(Console.ReadLine(), out newPin))
                {
                    Messages.EnterValidPostivePin();
                    continue;
                }

                accountToUpdate.Pin = newPin;
                Messages.UpdatedPinSuccessful(accountToUpdate.Name);
                pinUpdated = true;
            }
            else
            {
                Console.WriteLine("Incorrect old PIN. Please try again.");
            }
        }
    }

    public void TransferMoney(List<Account> accounts)
    {
        Console.Write("Enter account number to transfer to: ");
        int targetAccountNumber;
        while (!int.TryParse(Console.ReadLine(), out targetAccountNumber))
        {
            Messages.EnterValidAccountNumber();
        }

        var receiverAccount = accounts.FirstOrDefault(acc => acc.AccountNumber == targetAccountNumber);

        if (receiverAccount == null)
        {
            Messages.AccountNotFound();
            return;
        }

        if (receiverAccount.AccountNumber == account.AccountNumber)
        {
            Console.WriteLine("Invalid Transfer. You cannot transfer to your own account.");
            return;
        }

        Console.Write("Enter the amount to transfer: ");
        double amount;
        while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Messages.EnterPostiveAmount();
        }

        if (amount > account.Balance)
        {
            Messages.InsufficientBalance();
            return;
        }

        account.Balance -= amount;
        receiverAccount.Balance += amount;

        Messages.TransferSuccessful(amount, account.Name, receiverAccount.Name, account.Balance);
    }


}
