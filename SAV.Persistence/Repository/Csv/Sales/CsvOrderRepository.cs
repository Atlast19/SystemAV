

namespace SAV.Persistence.Repository.Csv.Sales
{
    using CsvHelper;
    using Microsoft.Extensions.Logging;
    using SAV.Application.Repository.Csv;
    using SAV.Application.Result;
    using SAV.Domain.Entity.Csv;
    public class CsvOrderRepository : IOrderFileReader
    {
        private readonly ILogger<CsvOrderRepository> _logger;
        public CsvOrderRepository(ILogger<CsvOrderRepository> logger)
        {
            _logger = logger;
        }
        public async Task<IEnumerable<Orders>> FileReader(IEnumerable<string> FilePath)
        {
            OperationResult<IEnumerable<Orders>> result = new OperationResult<IEnumerable<Orders>>();
            List<Orders> orders = new List<Orders>();

            _logger.LogInformation("Cargando los datos de los csv");
            try
            {
                var path = FilePath.First(x => x.Contains("orders.csv"));
                using var Reader = new StreamReader(path);
                    using var csv = new CsvReader(Reader, System.Globalization.CultureInfo.InvariantCulture);

                    await foreach (var record in csv.GetRecordsAsync<Orders>())
                    {
                        orders.Add(record);
                    }

                result = OperationResult<IEnumerable<Orders>>.Succes("Proceso completado sin errores");
            }
            catch (Exception ex)
            {
                orders = null;
                _logger.LogError("Error al leer el archvo", ex);
                result = OperationResult<IEnumerable<Orders>>.Failuer("Error en el proceso");
            }
            return orders;
        }
    }
}
