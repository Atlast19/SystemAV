

namespace SAV.Persistence.Repository.Csv.Sales
{
    using SAV.Application.Repository.Csv.ISales;
    using SAV.Domain.Entity.Csv;
    public class CsvSalesRepository : ISalesRepository
    {
        private readonly IEnumerable<Orders> _orders;
        private readonly IEnumerable<Order_Details> _orderDetails;

        public CsvSalesRepository(IEnumerable<Orders> orders, IEnumerable<Order_Details> orderDetails )
        {
            _orders = orders;
            _orderDetails = orderDetails;
        }

        public async Task<IEnumerable<Sales>> GetSales()
        {
            List<Sales> Sales = new List<Sales>();
            var SalesResult = from O in _orders
                              join D in _orderDetails
                              on O.OrderID equals D.OrderID
                              select new Sales
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
