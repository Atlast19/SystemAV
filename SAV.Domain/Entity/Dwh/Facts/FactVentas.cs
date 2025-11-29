

namespace SAV.Domain.Entity.Dwh.Facts
{
    public class FactVentas
    {
        public int VentasKey { get; set; }
        public int OrderID { get; set; }
        public int Order_Details { get; set; }
        public int CustomerKey { get; set; }
        public int ProductKey { get; set; }
        public int DateKey { get; set; }
        public int StatusKey { get; set; }
        public int Quantity { get; set; }
        public Decimal LineTotal { get; set; }
        public Decimal UnitPrice { get; set; }
    }
}
