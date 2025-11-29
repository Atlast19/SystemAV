using SAV.Application.Interfaces;
using SAV.Application.Repository.Csv;
using SAV.Application.Repository.Csv.ISales;
using SAV.Application.Repository.Dwh;
using SAV.Persistence.Repository.Dwh;
using SAV.Persistence.Repository.Dwh.DwhContex;

namespace SAV.Presentaction
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {

                    try
                    {
                        using (var scope = _serviceProvider.CreateScope()) 
                        {
                            ISalesHandlerService salesHandlerService = GetServices(scope);

                            await salesHandlerService.ProcessingDataAsync();

                            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                        }
                    }
                    catch (Exception e) 
                    {
                        _logger.LogError("Error procesando los datos" + e);
                    }



                    
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

        private static ISalesHandlerService GetServices(IServiceScope scope)
        {
            var db = scope.ServiceProvider.GetRequiredService<DwhContext>();
            var csvCustomer = scope.ServiceProvider.GetRequiredService<ICustomerFileReader>();;
            var csvProducts = scope.ServiceProvider.GetRequiredService<IProductFileReader>();
            var csvOrders = scope.ServiceProvider.GetRequiredService<IOrderFileReader>();
            var csvOrderDetails = scope.ServiceProvider.GetRequiredService<IOrder_DetailsFilerReader>();
            var csvSales = scope.ServiceProvider.GetRequiredService<ISalesRepository>();

            var dwhRepo = scope.ServiceProvider.GetRequiredService<ILoadDwhRepository>();
            var inventoryHandlerService = scope.ServiceProvider.GetRequiredService<ISalesHandlerService>();
            return inventoryHandlerService;
        }
    }
}
