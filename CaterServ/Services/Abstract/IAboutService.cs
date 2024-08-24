using CaterServ.Dtos.AboutDtos;

namespace CaterServ.Services.Abstract
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAbouts();
        Task<ResultAboutDto> GetAboutById(string id);
        Task UpdateAbout(UpdateAboutDto aboutDto);
        Task CreateAbout(CreateAboutDto aboutDto);
        Task DeleteAbout(string id);
    }
}
