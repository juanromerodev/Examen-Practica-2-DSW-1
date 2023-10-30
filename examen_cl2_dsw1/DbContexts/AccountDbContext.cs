using Microsoft.EntityFrameworkCore;
using examen_cl2_dsw1.Models;

namespace examen_cl2_dsw1.DbContexts
{
    public class AccountDbContext:DbContext
    {
        public AccountDbContext()
        {

        }
        public AccountDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }


    }
}

    
