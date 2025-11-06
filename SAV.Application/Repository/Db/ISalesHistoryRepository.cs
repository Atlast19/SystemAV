

namespace SAV.Application.Repository.Db
{
    using SAV.Domain.Entity.Db;
    public interface ISalesHistoryRepository
    {
        Task<IEnumerable<SalesHistory>> GetSalesHistoryDataAsync();
    }
}
