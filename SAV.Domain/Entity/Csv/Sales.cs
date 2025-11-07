

namespace SAV.Domain.Entity.Csv
{
    public class Sales
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public Decimal TotalPrice { get; set; }
        public DateOnly OrderDate { get; set; }
    }
}
