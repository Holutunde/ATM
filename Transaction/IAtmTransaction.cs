public interface IAtmTransaction
{
    void CheckBalance();
    void DepositMoney();
    void WithdrawMoney();
    void UpdatePin(List<Account> accounts);
    void TransferMoney(List<Account> accounts);
}
