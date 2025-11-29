

namespace SAV.Domain.Entity.Dwh.Dimensions
{
    public class DimProducts
    {
        public int ProductKey { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryKey { get; set; }
        public Decimal ListPrice { get; set; }
        public int Stock { get; set; }
    }
}
