

public class AtmTransaction : IAtmTransaction
{
    private Account account;

    public AtmTransaction(Account account)
    {
        this.account = account;
    }


    public void CheckBalance()
    {
        Console.WriteLine($"Your current balance is: {account.Balance}");
    }

    public void DepositMoney()
    {
        Console.Write("Enter the amount to deposit: ");

        double amount;
        while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a positive number.");
            Console.Write("Enter the positive valid amount to deposit: ");
        }

        account.Balance += amount;
        Console.WriteLine($"{amount} deposited successfully in {account.Name}'s account. Your new balance is: {account.Balance}");
    }

    public void WithdrawMoney()
    {
        Console.Write("Enter the amount to withdraw: $");

        double amount;
        while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a positive number.");
            Console.Write("Enter the positive valid amount to withdraw: ");
        }

        if (amount > account.Balance)
        {
            Console.WriteLine("Insufficient balance.");
            return;
        }

        account.Balance -= amount;
        Console.WriteLine($"{amount} withdrawn successfully. Your new balance is: {account.Balance}");
    }

    public void UpdatePin(List<Account> accounts)
    {
        Console.Write("Enter your current 4 digit PIN: ");
        int oldPin;
        while (!int.TryParse(Console.ReadLine(), out oldPin))
        {
            Console.WriteLine("Invalid input. Please enter a valid 4 digit PIN.");
            Console.Write("Enter your current 4 digit PIN: ");
        }

        var accountToUpdate = accounts.Find(account => account.Pin == oldPin);
        if (accountToUpdate != null)
        {
            Console.Write("Enter your new 4 digit PIN: ");
            int newPin;
            while (!int.TryParse(Console.ReadLine(), out newPin))
            {
                Console.WriteLine("Invalid input. Please enter a valid 4 digit PIN.");
                Console.Write("Enter your new 4 digit PIN: ");
            }

            accountToUpdate.Pin = newPin;
            Console.WriteLine($"Pin updated successfully for account {accountToUpdate.Name}.");
        }
        else
        {
            Console.WriteLine("Account not found or PIN incorrect.");
        }
    }

    public void TransferMoney(List<Account> accounts)
    {
        Console.Write("Enter account number to transfer to: ");
        int targetAccountNumber;
        while (!int.TryParse(Console.ReadLine(), out targetAccountNumber))
        {
            Console.WriteLine("Invalid input. Please enter a valid account number.");
            Console.Write("Enter account number to transfer to: ");
        }

        var receiverAccount = accounts.Find(account => account.AccountNumber == targetAccountNumber);

        if (receiverAccount != null)
        {
            Console.Write("Enter the amount to transfer: ");
            double amount;
            while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
                Console.Write("Enter the positive valid amount to transfer: ");
            }

            if (amount > account.Balance)
            {
                Console.WriteLine("Insufficient balance for transfer.");
                return;
            }

            account.Balance -= amount;
            receiverAccount.Balance += amount;

            Console.WriteLine($"{amount} naira transferred successfully from {account.Name}'s account to {receiverAccount.Name}'s account.");
            Console.WriteLine($"Your new balance is: {account.Balance}");
        }
        else
        {
            Console.WriteLine("Receiver account not found.");
        }
    }
 
}
