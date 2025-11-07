


using SAV.Application.Repository.Csv.ISales;
using SAV.Domain.Entity.Csv;


namespace SAV.Persistence.Repository.Csv.Sales
{
    public class CsvSalesRepository : ISalesRepository
    {
        private readonly IEnumerable<Orders> _orders;
        private readonly IEnumerable<Order_Details> _orderDetails;

        public CsvSalesRepository(IEnumerable<Orders> orders, IEnumerable<Order_Details> orderDetails )
        {
            _orders = orders;
            _orderDetails = orderDetails;
        }

        public async Task<IEnumerable<Domain.Entity.Csv.Sales>> GetSales()
        {
            List<Domain.Entity.Csv.Sales> Sales = new List<Domain.Entity.Csv.Sales>();
            var SalesResult = from O in _orders
                              join D in _orderDetails
                              on O.OrderID equals D.OrderID
                              select new Domain.Entity.Csv.Sales
                              {
                                  OrderID = O.OrderID,
                                  CustomerID = O.CustomerID,
                                  OrderDate = O.OrderDate,
                                  ProductID = D.ProductID,
                                  Quantity = D.Quantity,
                                  TotalPrice = D.TotalPrice,
                              };

            foreach (var item in SalesResult)
            {
                Sales.Add(item);
            }
            return Sales;
        }
    }
}
