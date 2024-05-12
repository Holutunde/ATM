
public class StartTransaction
{
    public bool createTransaction = true;
    public void RunTransaction(List<Account> activatedAccounts)
    {

        Authentication authentication = new Authentication(activatedAccounts);

        while (createTransaction)
        {

            var selectedAccount = authentication.StartAuthentication();

            if (selectedAccount != null)
            {

                IAtmTransaction transaction = new AtmTransaction(selectedAccount);

                int decision = UserChoice.GetUserChoice();

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

                createTransaction = UserChoice.ContinueOrNot();
            }
            else
            {
                createTransaction = false;
                Console.WriteLine("Thank you for using Olutunde Bank.");
            }


        }
    }

}