

namespace SAV.Domain.Entity.Dwh.Dimensions
{
    public class DimDate
    {
        public int DateKey { get; set; }
        public DateOnly TheDate { get; set; }
        public int Year { get; set; }
        public int Quater { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string WeekDayName { get; set; }
        public string YearMonth { get; set; }
    }
}
