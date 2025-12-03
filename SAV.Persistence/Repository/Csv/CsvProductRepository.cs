

namespace SAV.Persistence.Repository.Csv
{
    using CsvHelper;
    using Microsoft.Extensions.Logging;
    using SAV.Application.Repository.Csv;
    using SAV.Application.Result;
    using SAV.Domain.Entity.Csv;
    public class CsvProductRepository : IProductFileReader
    {
        private readonly ILogger _logger;
        public CsvProductRepository( ILogger<CsvProductRepository> logger)
        { 
            _logger = logger;
        }
        public async Task<IEnumerable<Products>> FileReader(IEnumerable<string> FilePath)
        {
            OperationResult<IEnumerable<Products>> result = new OperationResult<IEnumerable<Products>>();
            List<Products> products = new List<Products>();

            _logger.LogInformation("Cargando los datos de los csv");
            try
            {
                var path = FilePath.First(x => x.Contains("products.csv"));
                using var Reader = new StreamReader(path);
                    using var csv = new CsvReader(Reader, System.Globalization.CultureInfo.InvariantCulture);

                    await foreach (var record in csv.GetRecordsAsync<Products>())
                    {
                        products.Add(record);
                    }

                result = OperationResult<IEnumerable<Products>>.Succes("Proceso completado sin errores");
            }
            catch (Exception ex)
            {
                products = null;
                _logger.LogError("Error al leer el archvo", ex);
                result = OperationResult<IEnumerable<Products>>.Failuer("Error en el proceso");
            }
            return products;
        }
    }
}
