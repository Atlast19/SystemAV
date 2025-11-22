
namespace SAV.Persistence.Repository.Dwh.DwhContex
{
    using Microsoft.EntityFrameworkCore;
    using SAV.Domain.Entity.Dwh.Dimensions;
    public class DwhContext : DbContext
    {
        public DwhContext(DbContextOptions<DwhContext> option) : base(option) {}

        public DbSet<DimProducts> DimProductos { get; set; }
        public DbSet<DimCategory> DimCategory { get; set; }
        public DbSet<DimCustomers> DimCustomer { get; set; }
        public DbSet<DimDate> DimDate { get; set; }
        public DbSet<DimStatus> DimStatus { get; set; }
    }
}
