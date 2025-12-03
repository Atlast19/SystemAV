

namespace SAV.Domain.Entity.Dwh.Dimensions
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DimCustomer",Schema ="Dimension")]
    public class DimCustomers
    {
        [Key]
        public int CustomerKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
