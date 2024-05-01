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
}
