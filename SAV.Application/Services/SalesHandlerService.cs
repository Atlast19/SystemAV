
namespace SAV.Application.Services
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using SAV.Application.Dtos.DimDtos;
    using SAV.Application.Interfaces;
    using SAV.Application.Repository.Dwh;
    using SAV.Application.Result;
    public class SalesHandlerService : ISalesHandlerService
    {
        private readonly ILoadDwhRepository _loadDwhRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<SalesHandlerService> _logger;
        public SalesHandlerService(ILoadDwhRepository loadDwhRepository, IConfiguration configuration, ILogger<SalesHandlerService> logger)
        {
            _loadDwhRepository = loadDwhRepository;
            _configuration = configuration;
            _logger = logger;
        }

        public ILogger<SalesHandlerService> Logger { get; }

        public async Task<ServiceResult> ProcessingDataAsync()
        {
            ServiceResult result = new ServiceResult();
            _logger.LogInformation("Procesando la data en el servicio");
            try
            {
                DimDtos dimDtos = new DimDtos();

                dimDtos.fileData = _configuration.GetSection("ConnectionStrings:CsvPathString").Get<string[]>();

                result = await _loadDwhRepository.LoadDimData(dimDtos);
            }
            catch (Exception e) 
            {
                result.IsSuccess = false;
                result.Message = e.Message;

                _logger.LogError("Error en el servicio"+ e);
            }

            return result;
        }
    }
}