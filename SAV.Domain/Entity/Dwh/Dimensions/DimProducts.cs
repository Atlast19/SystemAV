
namespace SAV.Domain.Entity.Dwh.Dimensions
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DimProduct",Schema = "Dimension")]
    public class DimProducts
    {
        [Key]
        public int ProductKey { get; set; }
        public string ProductName { get; set; }
        public int CategoryKey { get; set; }
        public decimal ListPrice { get; set; }
        public int Stock { get; set; }
    }
}
