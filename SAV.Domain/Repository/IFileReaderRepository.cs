
namespace SAV.Domain.Repository
{
    public interface IFileReaderRepository<TClass> where TClass : class
    {
        Task<IEnumerable<TClass>> FileReader(IEnumerable<string> FilePath);
    }
}
