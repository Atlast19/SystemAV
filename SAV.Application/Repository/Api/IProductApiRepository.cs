

namespace SAV.Application.Repository.Api
{
    using SAV.Application.Result;
    using SAV.Domain.Entity.Csv;
    public interface IProductApiRepository
    {
        Task<OperationResult<IEnumerable<Products>>> GetProductsAsync();
    }
}
