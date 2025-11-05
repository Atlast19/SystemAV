

namespace SAV.Application.Repository.Api
{
    using SAV.Domain.Entity.CSV;
    public interface IProductApiRepository
    {
        Task<IEnumerable<Products>> GetProductsAsync();
    }
}
