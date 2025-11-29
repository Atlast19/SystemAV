
namespace SAV.Application.Interfaces
{
    using SAV.Application.Result;
    public interface ISalesHandlerService
    {
        Task<ServiceResult> ProcessingDataAsync();
    }
}
