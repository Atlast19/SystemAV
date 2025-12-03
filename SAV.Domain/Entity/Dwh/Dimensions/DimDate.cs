

namespace SAV.Domain.Entity.Dwh.Dimensions
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DimDate", Schema = "Dimension")]
    public class DimDate
    {
        [Key]
        public int DateKey { get; set; }
        public DateTime TheDate { get; set; }
        public int Year { get; set; }
        public int Quater { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string WeekDayName { get; set; }
    }
}
