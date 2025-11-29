
namespace SAV.Application.Dtos.DimDtos
{
    using SAV.Domain.Entity.Csv;
    using SAV.Domain.Entity.Db;
    public class DimDtos
    {
        #region"Lista de los datos de API"
        public List<ProductDto> productsAPI { get; set; }
        public List<CustomerDto> custoemrsAPI { get; set; }
        #endregion

        #region"Lista de los datos de Csv"
        public string? fileData { get; set; }
        #endregion

        #region "Lista de los datos de BD"
        public List<SalesHistory> SalesHistoryDb { get; set; }
        #endregion

    }
}
