using examen_cl2_dsw1.Models;

namespace examen_cl2_dsw1.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<IEnumerable<Account>> GetAccounts(int page, int size);
        Task<Account> GetAccountById(int id);
        Task<Account> GetAccountByAccountNumber(string numAccount);
        Task<Account> CreateAccount(Account account);
        Task<Account> UpdateAccount(Account account);
        Task<bool> DeleteAccount(int id);
    }
}
