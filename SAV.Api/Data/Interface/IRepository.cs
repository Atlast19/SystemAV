namespace SAV.Api.Data.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetDataFromApi();
    }
}
