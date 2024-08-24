using CaterServ.Dtos.CheffDtos;

namespace CaterServ.Services.Abstract
{
    public interface ICheffService
    {
        Task<List<ResultCheffDto>> GetAllCheffs();
        Task<ResultCheffDto> GetCheffById(string id);
        Task UpdateCheff(UpdateCheffDto updateCheff);
        Task CreateCheff(CreateCheffDto createCheff);
        Task DeleteCheff(string id);
    }
}
