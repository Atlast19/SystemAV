
namespace SAV.Persistence.Repository.Dwh
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using SAV.Application.Dtos.DimDtos;
    using SAV.Application.Repository.Csv;
    using SAV.Application.Repository.Dwh;
    using SAV.Application.Result;
    using SAV.Domain.Entity.Dwh.Dimensions;
    using SAV.Persistence.Repository.Dwh.DwhContex;
    using System.Globalization;

    public class DwhRepository : ILoadDwhRepository
    {
        private readonly DwhContext _context;
        private readonly ILogger<DwhRepository> _logger;
        private readonly ICustomerFileReader _customerFileReader;
        private readonly IProductFileReader _productFileReader;
        private readonly IOrderFileReader _orderFileReader;

        public DwhRepository(DwhContext context,
            ICustomerFileReader customerFileReader,
            IProductFileReader productFileReader,
            IOrderFileReader orderFileReader,
            ILogger<DwhRepository> logger)
        {
            _context = context;
            _logger = logger;
            _customerFileReader = customerFileReader;
            _productFileReader = productFileReader;
            _orderFileReader = orderFileReader;

        }

        public async Task<ServiceResult> LoadDimData(DimDtos dimDtos)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                result = await CleanDimenssions();

                //Carga de la Dimencion de Category
                var ProductsData = await _productFileReader.FileReader(dimDtos.fileData);

                var category = ProductsData.Where(ct => ct != null).Select(ct => ct.Category.Trim())
                    .Distinct().
                    Where(ct => !string.IsNullOrEmpty(ct)).Select(ct => new DimCategory
                    {
                        CategoryName = ct
                    }).ToArray();

                await _context.DimCategory.AddRangeAsync(category);
                await _context.SaveChangesAsync();


                //Carga de la Dimencion de los productos
                var products = ProductsData.Where(pr => pr != null).Select(pr => new DimProducts
                {
                    ProductKey = pr.ProductID,
                    ProductName = pr.ProductName.Trim(),
                    CategoryKey = category.FirstOrDefault(ca => ca.CategoryName == pr.Category.Trim()).CategoryKey,
                    ListPrice = pr.Price,
                    Stock = pr.Stock
                }).ToArray();

                await _context.DimProductos.AddRangeAsync(products);


                //Carga de la Dimencion de Customers
                var CustomerData = await _customerFileReader.FileReader(dimDtos.fileData);

                var customer = CustomerData.Where(cs => cs != null).Select(cs => new DimCustomers
                {
                    CustomerKey = cs.CustomerID,
                    FirstName = cs.FirstName.Trim(),
                    LastName = cs.LastName.Trim(),
                    Email = cs.Email.Trim(),
                    Phone = cs.Phone.Trim(),
                    City = cs.City.Trim(),
                    Country = cs.Country.Trim() 
                }).ToArray();

                await _context.DimCustomer.AddRangeAsync(customer);


                //Carga de la Dimencion de Status
                var OrdersData = await _orderFileReader.FileReader(dimDtos.fileData);

                var status = OrdersData.Select(st => st.Status.Trim())
                    .Distinct()
                    .Where(st => !string.IsNullOrEmpty(st)).Select(st => new DimStatus 
                    {
                        StatusName = st
                    }).ToArray();

                await _context.DimStatus.AddRangeAsync(status);


                //Carga de la Dimnecion de Date
                var date = OrdersData.Select(dt => dt.OrderDate).Distinct()
                    .Select(dt => new DimDate 
                    {
                        TheDate = dt.Date,
                        Day = dt.Day,
                        Quater = (dt.Month - 1) / 3 + 1,
                        Month = dt.Month,
                        Year = dt.Year,
                        WeekDayName = dt.ToString("dddd", new CultureInfo("es-ES")),
                        DateKey = Convert.ToInt32(dt.Date.ToString("yyyyMMdd")),

                    });

                await _context.DimDate.AddRangeAsync(date);



                await _context.SaveChangesAsync();
            }
            catch (Exception e) 
            {
                _logger.LogError("Error Cargando las Dimensiones " + e); 
            }

            return result;
        }

        private async Task<ServiceResult> CleanDimenssions() 
        {
            ServiceResult result = null;

            try
            {
                await _context.DimCategory.ExecuteDeleteAsync();
                await _context.DimProductos.ExecuteDeleteAsync();
                await _context.DimCustomer.ExecuteDeleteAsync();
                await _context.DimStatus.ExecuteDeleteAsync();
                await _context.DimDate.ExecuteDeleteAsync();

                await _context.SaveChangesAsync();

                result = new ServiceResult() { IsSuccess = true, Message = "La data de las dimensiones fueron limpiadas." };
            }
            catch (Exception e) 
            {
                result = new ServiceResult()
                {
                    IsSuccess = false,
                    Message = $"Error limpiando: {e.Message}"
                };
            }
            return result;
        }
    }
}
