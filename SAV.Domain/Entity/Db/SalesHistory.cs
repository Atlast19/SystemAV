

namespace SAV.Domain.Entity.Db
{
    public class SalesHistory
    {
        public int OrdersId { get; set; }

        public int? CustomerId { get; set; }

        public string OrderDate { get; set; }

        public int? Año { get; set; }

        public int? ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; }
    }
}
