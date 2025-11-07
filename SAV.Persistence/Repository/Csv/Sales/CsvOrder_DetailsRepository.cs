

namespace SAV.Persistence.Repository.Csv.Sales
{
    using CsvHelper;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using SAV.Application.Repository.Csv;
    using SAV.Application.Result;
    using SAV.Domain.Entity.Csv;
    internal class CsvOrder_DetailsRepository : IOrder_DetailsFilerReader
    {
        private readonly string? _FilePath;
        private readonly ILogger<CsvOrder_DetailsRepository> _logger;
        private readonly IConfiguration _configuration;
        public CsvOrder_DetailsRepository(IConfiguration configuration, ILogger<CsvOrder_DetailsRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _FilePath = _configuration["CsvOrdersFilePath"];
        }
        public async Task<IEnumerable<Order_Details>> FileReader(string FilePath)
        {
            OperationResult<IEnumerable<Order_Details>> result = new OperationResult<IEnumerable<Order_Details>>();
            List<Order_Details> order_detail = new List<Order_Details>();

            _logger.LogInformation("Leyendo el archivo csv", _FilePath);

            try
            {
                using var Reader = new StreamReader(FilePath);
                using var csv = new CsvReader(Reader, System.Globalization.CultureInfo.InvariantCulture);

                await foreach (var record in csv.GetRecordsAsync<Order_Details>())
                {
                    order_detail.Add(record);
                }
                result = OperationResult<IEnumerable<Order_Details>>.Succes("Proceso completado sin errores");
            }
            catch (Exception ex)
            {
                order_detail = null;
                _logger.LogError("Error al leer el archvo", ex);
                result = OperationResult<IEnumerable<Order_Details>>.Failuer("Error en el proceso");
            }
            return order_detail;
        }
    }
}
