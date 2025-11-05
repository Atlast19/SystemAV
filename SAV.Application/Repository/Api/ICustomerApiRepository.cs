

namespace SAV.Application.Repository.Api
{
    using SAV.Application.Result;
    using SAV.Domain.Entity.CSV;
    public interface ICustomerApiRepository
    {
        Task<OperationResult<IEnumerable<Customers>>> GetCustomersAsync();
    }
}
