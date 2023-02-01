using Microsoft.EntityFrameworkCore;

namespace BestBook2.Data
{

    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
           : base(options)
        {
        }
        public DbSet<BestBook2.Data.BookMaster> BookMaster { get; set; }
    }

}
