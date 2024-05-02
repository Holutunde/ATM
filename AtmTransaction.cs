

public class AtmTransaction : IAtmTransaction
{
    private Account account;

    public AtmTransaction(Account account)
    {
        this.account = account;
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
        Console.Write("Enter the amount to withdraw: $");

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
