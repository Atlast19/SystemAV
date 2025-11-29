

namespace SAV.Persistence.Repository.Api
{
    using Microsoft.Extensions.Logging;
    using SAV.Application.Repository.Api;
    using SAV.Application.Result;
    using SAV.Domain.Entity.Csv;
    using System.Net.Http.Json;

    public class CustomerApiRepository : ICustomerApiRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CustomerApiRepository> _logger;

        public CustomerApiRepository(HttpClient httpClient,ILogger<CustomerApiRepository> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        public async Task<OperationResult<IEnumerable<Customers>>> GetCustomersAsync()
        {
            OperationResult<IEnumerable<Customers>> result = new OperationResult<IEnumerable<Customers>>();
            List<Customers> customers = new List<Customers>();
            _logger.LogInformation("Cargando los datos de la API Externa");

            try
            {
                var customerAPI = await _httpClient.GetFromJsonAsync<IEnumerable<Customers>>("http://localhost:5008/Api/Customer/GetCustomers"); // url del enpoint
                _logger.LogInformation("Datos de la API Eterna cargados correctamente");
                customers.AddRange(customerAPI);
                result = OperationResult<IEnumerable<Customers>>.Succes("Proceso completado correctamente");
            }
            catch (Exception ex) 
            {
                _logger.LogError("Error al cargar los datos de la API Externa", ex);
                result = OperationResult<IEnumerable<Customers>>.Failuer("Error en el proceso de cargar los datos");
            }
            return result;

        }
    }
}
