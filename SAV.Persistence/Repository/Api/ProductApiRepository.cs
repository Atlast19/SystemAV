

using Microsoft.Extensions.Logging;
using SAV.Application.Repository.Api;
using SAV.Application.Result;
using SAV.Domain.Entity.CSV;
using System.Net.Http.Json;

namespace SAV.Persistence.Repository.Api
{
    public class ProductApiRepository : IProductApiRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductApiRepository> _logger;

        public ProductApiRepository(HttpClient httpClient, ILogger<ProductApiRepository> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<OperationResult<IEnumerable<Products>>> GetProductsAsync()
        {
            OperationResult<IEnumerable<Products>> result = new OperationResult<IEnumerable<Products>>();
            List<Products> products = new List<Products>();
            _logger.LogInformation("Cargando los datos de la API Externa");

            try
            {
                var ProductAPI = await _httpClient.GetFromJsonAsync<IEnumerable<Products>>(""); // url del enpoint
                _logger.LogInformation("Datos de la API Eterna cargados correctamente");
                products.AddRange(ProductAPI);
                result = OperationResult<IEnumerable<Products>>.Succes("Proceso completado correctamente");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al cargar los datos de la API Externa", ex);
                result = OperationResult<IEnumerable<Products>>.Failuer("Error en el proceso de cargar los datos");
            }
            return result;
        }
    }
}
