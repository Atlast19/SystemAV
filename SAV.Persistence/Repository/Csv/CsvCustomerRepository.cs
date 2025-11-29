

namespace SAV.Persistence.Repository.Csv
{
    using CsvHelper;
    using Microsoft.Extensions.Logging;
    using SAV.Application.Repository.Csv;
    using SAV.Application.Result;
    using SAV.Domain.Entity.Csv;
    public class CsvCustomerRepository : ICustomerFileReader
    {
        private readonly ILogger<CsvCustomerRepository> _logger;
        public CsvCustomerRepository(ILogger<CsvCustomerRepository> logger)
        {
            _logger = logger;
        }
        public async Task<IEnumerable<Customers>> FileReader(string FilePath)
        {
            OperationResult<IEnumerable<Customers>> result = new OperationResult<IEnumerable<Customers>>();
            List<Customers> customers = new List<Customers>();

            _logger.LogInformation("Cargando los datos de los csv");
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
