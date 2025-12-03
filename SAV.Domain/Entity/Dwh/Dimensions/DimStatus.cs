

namespace SAV.Domain.Entity.Dwh.Dimensions
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DimStatus",Schema ="Dimension")]
    public class DimStatus
    {
        [Key]
        public int StatusKey { get; set; }
        public string StatusName { get; set; }
    }
}
