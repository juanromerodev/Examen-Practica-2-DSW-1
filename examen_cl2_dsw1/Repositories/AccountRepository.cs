using examen_cl2_dsw1.DbContexts;
using examen_cl2_dsw1.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<Account> CreateAccount(Account account)
        {
            dbContext.Accounts.Add(account);
            await dbContext.SaveChangesAsync();
            return account;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var account = await dbContext.Accounts.FirstOrDefaultAsync(c => c.Id == id);
            if (account == null)
            {
                return false;
            }

            dbContext.Accounts.Remove(account);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Account> GetAccountByAccountNumber(string numAccount)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetAccountById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Account>> GetAccounts(int page, int size)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
