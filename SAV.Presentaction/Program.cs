
namespace SAV.Presentaction
{
    using Microsoft.EntityFrameworkCore;
    using SAV.Application.Interfaces;
    using SAV.Application.Repository.Csv;
    using SAV.Application.Repository.Csv.ISales;
    using SAV.Application.Repository.Dwh;
    using SAV.Application.Services;
    using SAV.Persistence.Repository.Csv;
    using SAV.Persistence.Repository.Csv.Sales;
    using SAV.Persistence.Repository.Dwh;
    using SAV.Persistence.Repository.Dwh.DwhContex;
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);


            builder.Services.AddDbContext<DwhContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DwhConecctionString")));
            builder.Services.AddScoped<ICustomerFileReader, CsvCustomerRepository>();
            builder.Services.AddScoped<IProductFileReader, CsvProductRepository>();
            builder.Services.AddScoped<IOrderFileReader, CsvOrderRepository>();
            builder.Services.AddScoped<IOrder_DetailsFilerReader, CsvOrder_DetailsRepository>();
            builder.Services.AddScoped<ISalesRepository, CsvSalesRepository>();

            builder.Services.AddScoped<ILoadDwhRepository, DwhRepository>();

            
            builder.Services.AddScoped<ISalesHandlerService, SalesHandlerService>();

            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
        }
    }
}