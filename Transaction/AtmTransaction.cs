

public class AtmTransaction : IAtmTransaction
{
    private readonly IAccount account;

    public AtmTransaction(IAccount account)
    {
       this.account = account;
    }
    public static void CreateAccount(List<Account> accounts)
    {
        Console.Write("Please enter your full name (firstname lastname): ");
        string? username = Console.ReadLine();

        Console.Write("Enter your 4-digit PIN: ");
        int pin;
        while (!int.TryParse(Console.ReadLine(), out pin) || pin.ToString().Length != 4 )
        {
            Messages.EnterValidPostivePin();
        }


       long  accountNumber = AtmTransaction.RandomAccountNumber();

        DateTime currentDate = DateTime.Now;
        var newDate =  currentDate.ToShortDateString();

        // Create the account and add it to the accounts list
        double newBalance = 100;
        Account newAccount = new()
        {
            Name = username,
            AccountNumber = accountNumber,
            Pin = pin,
            Balance = newBalance,
            OpeningDate = DateTime.Now
        };

       
        accounts.Add(newAccount);

        // Add the account to the Excel sheet
        RegisteredAccounts.AddAccount(newAccount);

        Messages.AccoutCreatedSuccessfully(accountNumber);
    }

   public static long RandomAccountNumber()
    {     
         // Generate a random 10-digit account number
        Random random = new Random();
        long accountNumber = (long)(random.NextDouble() * 9000000000) + 1000000000;
        return accountNumber;
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

        RegisteredAccounts.UpdateAccount(account);
        
        Messages.WithdrawSuccessful(amount, account.Balance);
    }

    public void UpdatePin(List<Account> accounts)
    {
        bool pinUpdated = false;

        while (!pinUpdated)
        {
            Console.Write("Enter your current 4 digit PIN: ");
         
            if (!int.TryParse(Console.ReadLine(), out int oldPin))
            {
                Messages.EnterValidPostivePin();
                continue;
            }

            var accountToUpdate = accounts.Find(account => account.Pin == oldPin);
            if (accountToUpdate != null)
            {
                Console.Write("Enter your new 4 digit PIN: ");
                int newPin;
                while (!int.TryParse(Console.ReadLine(), out newPin) || newPin.ToString().Length != 4)
                {
                    Messages.EnterValidPostivePin();
                    continue;
                }

                accountToUpdate.Pin = newPin;
        
                Messages.UpdatedPinSuccessful(accountToUpdate.Name);

                RegisteredAccounts.UpdateAccount(accountToUpdate);

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
        while (true)
        {
            Console.Write("Enter account number to transfer to: ");
            if (!int.TryParse(Console.ReadLine(), out int targetAccountNumber))
            {
                Messages.EnterValidAccountNumber();
                continue;
            }

            if (targetAccountNumber.ToString().Length != 10)
            {
                Console.WriteLine("Account number must be 10 digits");
                continue;
            }

            var receiverAccount = accounts.FirstOrDefault(acc => acc.AccountNumber == targetAccountNumber);

            if (receiverAccount == null)
            {
                Messages.AccountNotFound();
                continue;
            }

            if (receiverAccount.AccountNumber == account.AccountNumber)
            {
                Console.WriteLine("Invalid Transfer. You cannot transfer to your own account.");
                continue; 
            }

            Console.Write("Enter the amount to transfer: ");
            if (!double.TryParse(Console.ReadLine(), out double amount) || amount <= 0)
            {
                Messages.EnterPostiveAmount();
                continue;
            }

            if (amount > account.Balance)
            {
                Messages.InsufficientBalance();
                continue; 
            }

            // Perform the transfer
            account.Balance -= amount;
            receiverAccount.Balance += amount;
            RegisteredAccounts.UpdateAccount(account);
            RegisteredAccounts.UpdateAccount(receiverAccount);

            Messages.TransferSuccessful(amount, account.Name, receiverAccount.Name, account.Balance);
            break;
        }
    }


}
