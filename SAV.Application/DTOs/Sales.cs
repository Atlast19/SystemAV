

namespace SAV.Application.DTOs
{
    public class Sales
    {
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public Decimal TotalPrice { get; set; }
        public DateOnly OrderDate { get; set; }
        public string Status { get; set; }
    }
}
