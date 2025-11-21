

namespace SAV.Persistence.Repository.Db
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using SAV.Application.Repository.Db;
    using SAV.Domain.Entity.Db;
    using SAV.Persistence.Repository.Db.Context;

    public class SalesHistoryRepository : ISalesHistoryRepository
    {
        private readonly SalesHistoryContext _context;
        private readonly ILogger<SalesHistoryRepository> _logger;

        public SalesHistoryRepository(SalesHistoryContext context, ILogger<SalesHistoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<SalesHistory>> GetSalesHistoryDataAsync()
        {
            _logger.LogInformation("Cargando vista de labase de datos");
            return await _context.SalesHistory.ToListAsync();
        }
    }
}
