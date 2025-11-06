

namespace SAV.Api.Data.Repositoy
{
    using Microsoft.EntityFrameworkCore;
    using SAV.Api.Data.Context;
    using SAV.Api.Data.Entity;
    using SAV.Api.Data.Interface;
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly ApiContext _context;

        public CustomerRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetDataFromApi()
        {
            return await _context.customer.ToArrayAsync();
        }
    }
}
