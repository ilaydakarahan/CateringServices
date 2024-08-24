using CaterServ.Dtos.EventCategoryDtos;

namespace CaterServ.Services.Abstract
{
    public interface IEventCategoryService
    {
        Task<List<ResultEventCategoryDto>> GetAllEventCategory();
        Task<ResultEventCategoryDto> GetEventCategoryById(string id);
        Task UpdateEventCategory(UpdateEventCategoryDto eventCategoryDto);
        Task CreateEventCategory(CreateEventCategoryDto eventCategoryDto);
        Task DeleteEventCategory(string id);
    }
}
