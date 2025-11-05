

namespace SAV.Application.Repository.Api
{
    using SAV.Application.Result;
    using SAV.Domain.Entity.CSV;
    public interface IProductApiRepository
    {
        Task<OperationResult<IEnumerable<Products>>> GetProductsAsync();
    }
}
