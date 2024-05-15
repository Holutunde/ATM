public class UserChoice
{
    public static int GetUserChoice()
    {
        Console.WriteLine("Olutunde Bank, welcome our Esteemed customer");
        Console.WriteLine("1. Check Balance");
        Console.WriteLine("2. Deposit Money");
        Console.WriteLine("3. Withdraw Money");
        Console.WriteLine("4. Update Pin");
        Console.WriteLine("5. Transfer Money");
        Console.WriteLine("6. Exit");

        int decision;
        while (true)
        {
            Console.Write("Enter your choice from 1-6: ");
            if (!int.TryParse(Console.ReadLine(), out decision))
            {
                Console.WriteLine("Invalid input format. Please enter a valid number 1-6.");
                continue;
            }

            if (decision >= 1 && decision <= 6)
            {
                return decision;
            }
            else
            {
                Console.WriteLine("Number is not from 1 - 6. Enter a valid number.");
            }
        }
    }
    public static bool ContinueOrNot()
    {
        Console.Write("Do you want to continue transaction (yes/no): ");
        string? response = Console.ReadLine()?.ToLower();

        List<string> yesNoOptions = new() { "yes", "no", "y", "n" };

        if(response != null)
        {
            if (!yesNoOptions.Contains(response))
            {
                Console.WriteLine("Invalid input. Please enter either 'yes' or 'no'.");
                return ContinueOrNot(); 
            }

            if (response == "no" || response == "n")
            {
                Console.WriteLine("Thank you for using Olutunde Bank.");
                return false;
            }
        }


        return true;
    }



    public static int WelcomeATM()
    {
        Console.WriteLine("Olutunde Bank, welcome our Esteemed customer");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");
        Console.WriteLine("3. Exit");
     ;

        int choice;

        while (true)
        {
            Console.Write("Enter your choice from 1-3: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input format. Please enter a positive number 1-3.");
                continue;
            }

            if (choice >= 1 && choice <= 3)
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Input is not from 1 - 3. Enter a valid number.");
            }
        }
    }
}
