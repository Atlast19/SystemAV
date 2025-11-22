

namespace SAV.Application.Repository.Dwh
{
    using SAV.Application.Dtos.DimDtos;
    using SAV.Application.Result;
    public interface ILoadDwhRepository
    {
        Task<ServiceResult> LoadDimData(DimDtos dimDtos); 
    }
}
