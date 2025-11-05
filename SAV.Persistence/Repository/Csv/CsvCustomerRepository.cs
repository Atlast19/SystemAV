

namespace SAV.Persistence.Repository.Csv
{
    using CsvHelper;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using SAV.Application.Repository.Csv;
    using SAV.Application.Result;
    using SAV.Domain.Entity.CSV;
    public class CsvCustomerRepository : ICustomerFileReader
    {
        private readonly string? _FilePath;
        private readonly ILogger<CsvCustomerRepository> _logger;
        private readonly IConfiguration _configuration;
        public CsvCustomerRepository(IConfiguration configuration, ILogger<CsvCustomerRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _FilePath = _configuration["CsvCustomerFilePath "];
        }
        public async Task<IEnumerable<Customers>> FileReader(string FilePath)
        {
            OperationResult<IEnumerable<Customers>> result = new OperationResult<IEnumerable<Customers>>();
            List<Customers> customers = new List<Customers>();

            _logger.LogInformation("Leyendo el archivo csv", _FilePath);

            try
            {
                using var Reader = new StreamReader(FilePath);
                using var csv = new CsvReader(Reader, System.Globalization.CultureInfo.InvariantCulture);

                await foreach (var record in csv.GetRecordsAsync<Customers>())
                {
                    customers.Add(record);
                }
                result = OperationResult<IEnumerable<Customers>>.Succes("Proceso completado sin errores");
            }
            catch (Exception ex) 
            {
                customers = null;
                _logger.LogError("Error al leer el archvo", ex);
                result = OperationResult<IEnumerable<Customers>>.Failuer("Error en el proceso");
            }
            return customers;
        }
    }
}
