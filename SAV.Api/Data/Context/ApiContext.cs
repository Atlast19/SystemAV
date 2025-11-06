using Microsoft.EntityFrameworkCore;
using SAV.Api.Data.Entity;

namespace SAV.Api.Data.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> option) : base(option) { }

        public DbSet<Customer> customer { get; set; }
        public DbSet<Product> product { get; set; }
    }
}
