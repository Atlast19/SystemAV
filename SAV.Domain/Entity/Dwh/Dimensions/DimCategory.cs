
namespace SAV.Domain.Entity.Dwh.Dimensions
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DimCategory",Schema ="Dimension")]
    public class DimCategory
    {
        [Key]
        public int CategoryKey { get; set; }
        public string CategoryName { get; set; }
    }
}
