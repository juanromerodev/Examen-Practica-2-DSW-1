using examen_cl2_dsw1.DbContexts;
using examen_cl2_dsw1.Models;
using examen_cl2_dsw1.Exceptions;
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
            var account = await dbContext.Accounts.Where(c => c.AccountNumber == numAccount).FirstOrDefaultAsync();
            if (account == null)
            {
                throw new NotFoundException($"Account not found with number {numAccount}");
            }
            return account;
        }

        public async Task<Account> GetAccountById(int id)
        {
            var account = await dbContext.Accounts.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (account == null)
            {
                throw new NotFoundException($"Account not found with id {id}");
            }
            return account;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await dbContext.Accounts.ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAccounts(int page, int size)
        {
            var result = await this.dbContext.Accounts
                .Skip(page * size) 
                .Take(size) 
                .ToListAsync();

            if (result == null)
            {
                throw new Exception();
            }
            else if (result.Count == 0)
            {
                throw new NotFoundException("Account list is empty");
            }

            return result;
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            dbContext.Accounts.Update(account);
            await dbContext.SaveChangesAsync();
            return account;
        }
    }
}
