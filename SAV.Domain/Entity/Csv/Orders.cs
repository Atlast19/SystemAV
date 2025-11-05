

namespace SAV.Domain.Entity.Csv
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateOnly OrderDate { get; set; }
        public string Status { get; set; }
    }
}
