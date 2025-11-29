

namespace SAV.Application.Repository.Api
{
    using SAV.Application.Result;
    using SAV.Domain.Entity.Csv;
    public interface ICustomerApiRepository
    {
        Task<OperationResult<IEnumerable<Customers>>> GetCustomersAsync();
    }
}
