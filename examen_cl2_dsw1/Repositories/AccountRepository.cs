using examen_cl2_dsw1.DbContexts;
using examen_cl2_dsw1.Models;

namespace examen_cl2_dsw1.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext dbContext;
        public AccountRepository(AccountDbContext dbContext)
        {
            //por inyeccion de dependencia se instancia la clase(crear el objeto)
            this.dbContext = dbContext;
        }
        public Task<Account> CreateAccount(Account account)
        {
            dbContext.Accounts.Add(account);
            await dbContext.SaveChangesAsync();
            return account;
        }

        public Task<bool> DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountByAccountNumber(string numAccount)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAccounts(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<Account> UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
