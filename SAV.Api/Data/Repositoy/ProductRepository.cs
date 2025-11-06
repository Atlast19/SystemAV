using Microsoft.EntityFrameworkCore;
using SAV.Api.Data.Context;
using SAV.Api.Data.Entity;
using SAV.Api.Data.Interface;

namespace SAV.Api.Data.Repositoy
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApiContext _context;

        public ProductRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetDataFromApi()
        {
            return await _context.product.ToArrayAsync();
            
        }
    }
}
