public class Account : IAccount
{
    public string? Name { get; set; }
    public long AccountNumber { get; set; }
    public int Pin { get; set; }
    public double Balance { get; set; }

    public DateTime OpeningDate { get; set; }
}
