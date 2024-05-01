public class Authentication
{
    private List<Account> accounts;
    private bool AuthenticateUserAccount = true;
    public int InputtedAccountNumber { get; set; }

    public Authentication(List<Account> accounts)
    {
        this.accounts = accounts;
    }


    private bool AuthenticateAccount(int inputAccountNumber, int inputPin)
    {
        var account = accounts.Find(acc => acc.AccountNumber == inputAccountNumber && acc.Pin == inputPin);
        return account != null;
    }


    public bool StartAuthentication()
    {
        while (AuthenticateUserAccount)
        {
            Console.Write("Enter your account number: ");
            if (!int.TryParse(Console.ReadLine(), out int inputAccountNumber))
            {
                Console.WriteLine("Invalid input format. Please enter a numeric account number.");
                continue;
            }

            var account = accounts.Find(acc => acc.AccountNumber == inputAccountNumber);
            if (account == null)
            {
                Console.WriteLine("Account number not found. Please try again.");
                continue;
            }

            InputtedAccountNumber = inputAccountNumber;

            for (int attempts = 0; attempts < 4; attempts++)
            {
                Console.Write("Enter your 4 digit pin: ");
                if (!int.TryParse(Console.ReadLine(), out int inputPin))
                {
                    Console.WriteLine("Invalid input format. Please enter a numeric pin.");
                    continue;
                }

                if (AuthenticateAccount(inputAccountNumber, inputPin))
                {
                    Console.WriteLine("Correct pin entered.");
                    return true; 
                }

                Console.WriteLine("Incorrect pin!!! Confirm and enter correct pin.");
            }

            Console.WriteLine("Max attempts reached. Account suspended, visit the bank for further inquiries.");
            AuthenticateUserAccount = false;
        }

        return false;
    }


}
