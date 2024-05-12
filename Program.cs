StartTransaction myAtmTransaction = new StartTransaction();
    // List<Account> activatedAccounts = new();
var activatedAccounts = RegisteredAccounts.GetAccounts();


int choice = UserChoice.WelcomeATM();
switch (choice)
{
    case 1:
        myAtmTransaction.RunTransaction(activatedAccounts);
        break;
    case 2:
        AtmTransaction.CreateAccount(activatedAccounts);
        var outcome = UserChoice.ContinueOrNot();
        if (outcome == true)
        {
            myAtmTransaction.RunTransaction(activatedAccounts);
        }
        break;
    case 3:
        Console.WriteLine("Thank you for using Olutunde Bank.");
        break;
    default:
        Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
        break;
}

