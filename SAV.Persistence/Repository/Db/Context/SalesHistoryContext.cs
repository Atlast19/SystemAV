

using Microsoft.EntityFrameworkCore;
using SAV.Domain.Entity.Db;

namespace SAV.Persistence.Repository.Db.Context
{
    public class SalesHistoryContext : DbContext
    {
        public SalesHistoryContext(DbContextOptions<SalesHistoryContext> options) : base(options)
        {
            
        }
        public DbSet<SalesHistory> SalesHistories { get; set; }
    }
}
