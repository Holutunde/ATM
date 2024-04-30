using System.Security.Principal;

public class Transaction
{
    double balance = 1000;
    bool doTransaction = false;
    bool createTransaction = true;
    int inputCount = 0;
    int inputPin;


    List<Account> accounts = new List<Account>();

    public void AtmTransaction()
    {
        accounts.Add(new Account("Olutunde Sokunbi", 1234567890, 1234, 4567.45));
        accounts.Add(new Account("Tayo Gbotemi", 678912345, 3456, 10));
        accounts.Add(new Account("Shoremi Bankole", 345678912, 7890, 89.45));
        accounts.Add(new Account("Baba t", 789078906, 4567, 2000));

        while (createTransaction)
        {
            Console.Write("Enter your 4 digit pin: ");

            if (!int.TryParse(Console.ReadLine(), out inputPin))
            {
                Console.WriteLine("Invalid input format. Please enter a numeric pin.");
                continue;
            }

            var account = Account.GetAccountByPin(accounts, inputPin);

            if (account == null)
            {
                inputCount++;
                Console.WriteLine("Incorrect pin!!! Confirm and enter correct pin.");
            }
            else
            {
                Console.WriteLine("Correct pin entered.");
                doTransaction = true;
                break;
            }

            if (inputCount == 4)
            {
                Console.WriteLine("Account suspended, visit the bank for further inquiries.");
                createTransaction = false;
                break;
            }
        }

        while (doTransaction)
        {
            Console.WriteLine("Olutunde Bank, welcome our Esteemed customer");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Update Pin");
            Console.WriteLine("5. Transfer Money");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice from 1-5: ");
            int decision;

            if (!int.TryParse(Console.ReadLine(), out decision))
            {
                Console.WriteLine("Invalid input. Please enter a number from 1 to 5.");
                continue;
            }



            switch (decision)
            {
                case 1:
                    var account1 = Account.GetAccountByPin(accounts, inputPin);
                    account1.CheckBalance();
                    break;
                case 2:
                    var account2 = Account.GetAccountByPin(accounts, inputPin);
                    account2.DepositMoney();
                    break;
                case 3:
                    var account3 = Account.GetAccountByPin(accounts, inputPin);
                    account3.WithdrawMoney();
                    break;
                case 4:
                    var account4 = Account.GetAccountByPin(accounts, inputPin);
                    account4.UpdatePin(accounts);
                    break;
                case 5:
                    var account5 = Account.GetAccountByPin(accounts, inputPin);
                    account5.TransferMoney(accounts);
                    break;
                case 6:
                    Console.WriteLine("Thank you for using Olutunde Bank.");
                    doTransaction = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }

            Console.Write("Do you want to continue transaction(yes/no): ");
            string response = Console.ReadLine();

            if (response.ToLower() == "no")
            {
                createTransaction = false;
                Console.WriteLine("Thank you for using Olutunde Bank.");
            }
        }
    }
}



