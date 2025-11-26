
namespace SAV.Persistence.Repository.Dwh
{
    using Microsoft.Extensions.Logging;
    using SAV.Application.Dtos.DimDtos;
    using SAV.Application.Repository.Dwh;
    using SAV.Application.Result;
    using SAV.Persistence.Repository.Dwh.DwhContex;
    public class DwhRepository : ILoadDwhRepository
    {
        private readonly DwhContext _context;
        private readonly ILogger<DwhRepository> _logger;

        public DwhRepository(DwhContext context, ILogger<DwhRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<ServiceResult> LoadDimData(DimDtos dimDtos)
        {
            throw new NotImplementedException();
        }
    }
}
