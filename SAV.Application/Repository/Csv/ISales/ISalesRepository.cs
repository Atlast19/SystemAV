

using SAV.Domain.Entity.Csv;

namespace SAV.Application.Repository.Csv.ISales
{
    public interface ISalesRepository
    {
        Task<IEnumerable<Sales>> GetSales();
    }
}
