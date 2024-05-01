public class ContinueTransactionOrNot
{
    public static bool ContinueOrNot(bool createTransaction)
    {
        Console.Write("Do you want to continue transaction (yes/no): ");
        string response = Console.ReadLine();

        if (response.ToLower() == "no")
        {
            createTransaction = false;
            Console.WriteLine("Thank you for using Olutunde Bank.");
        }

        return createTransaction;
    }
}
