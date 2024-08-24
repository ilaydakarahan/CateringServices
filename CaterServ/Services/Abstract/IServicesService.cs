using CaterServ.Dtos.ServiceDtos;

namespace CaterServ.Services.Abstract
{
    public interface IServicesService
    {
        Task<List<ResultServiceDto>> GetAllServices();
        Task<ResultServiceDto> GetServiceById(string id);
        Task UpdateService(UpdateServiceDto serviceDto);
        Task CreateService(CreateServiceDto serviceDto);
        Task DeleteService(string id);
    }
}
