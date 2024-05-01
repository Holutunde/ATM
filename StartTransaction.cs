using System.Collections.Generic;

public class StartTransaction
{
    private bool createTransaction = true;


    public void RunTransaction()
    {
        RegisteredAccounts registeredAccounts = new RegisteredAccounts();
        List<Account> activatedAccounts = registeredAccounts.GetAccounts();

        Authentication authentication = new Authentication(activatedAccounts);

        while (createTransaction)
        {
            if (!authentication.StartAuthentication())
            {
                Console.WriteLine("Authentication failed. Please try again.");
                break;
            }

            int decision = UserChoice.GetUserChoice();

            var selectedAccount = activatedAccounts.Find(acc => acc.AccountNumber == authentication.InputtedAccountNumber);

            IAtmTransaction transaction = new AtmTransaction(selectedAccount);

            switch (decision)
            {
                case 1:
                    transaction.CheckBalance();
                    break;
                case 2:
                    transaction.DepositMoney();
                    break;
                case 3:
                    transaction.WithdrawMoney();
                    break;
                case 4:
                    transaction.UpdatePin(activatedAccounts);
                    break;
                case 5:
                    transaction.TransferMoney(activatedAccounts);
                    break;
                case 6:
                    Console.WriteLine("Thank you for using Olutunde Bank.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                    break;
            }

            createTransaction = ContinueTransactionOrNot.ContinueOrNot(createTransaction);
        }
    }

}
