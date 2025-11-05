

namespace SAV.Domain.Entity.Csv
{
    public class Order_Details
    {
        public int Order_DetailID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public Decimal TotalPrice { get; set; }
    }
}
