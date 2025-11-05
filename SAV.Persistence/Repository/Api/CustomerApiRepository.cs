

namespace SAV.Persistence.Repository.Api
{
    using SAV.Application.Repository.Api;
    using SAV.Domain.Entity.CSV;

    public class CustomerApiRepository : ICustomerApiRepository
    {
        public Task<IEnumerable<Customers>> GetCustomersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
