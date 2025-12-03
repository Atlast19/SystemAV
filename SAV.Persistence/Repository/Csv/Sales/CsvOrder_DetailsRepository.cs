

namespace SAV.Persistence.Repository.Csv.Sales
{
    using CsvHelper;
    using Microsoft.Extensions.Logging;
    using SAV.Application.Repository.Csv;
    using SAV.Application.Result;
    using SAV.Domain.Entity.Csv;
    public class CsvOrder_DetailsRepository : IOrder_DetailsFilerReader
    {
        private readonly ILogger<CsvOrder_DetailsRepository> _logger;
        public CsvOrder_DetailsRepository(ILogger<CsvOrder_DetailsRepository> logger)
        {
            _logger = logger;
        }
        public async Task<IEnumerable<Order_Details>> FileReader(IEnumerable<string> FilePath)
        {
            OperationResult<IEnumerable<Order_Details>> result = new OperationResult<IEnumerable<Order_Details>>();
            List<Order_Details> order_detail = new List<Order_Details>();

            _logger.LogInformation("Cargando los datos de los csv");
            try
            {
                var path = FilePath.First(x => x.Contains("order_details.csv"));
                using var Reader = new StreamReader(path);
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
