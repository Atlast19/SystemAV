

namespace SAV.Application.Repository.Api
{
    using SAV.Domain.Entity.CSV;
    public interface ICustomerApiRepository
    {
        Task<IEnumerable<Customers>> GetCustomersAsync();
    }
}
