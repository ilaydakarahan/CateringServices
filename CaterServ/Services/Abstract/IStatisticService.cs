using CaterServ.Dtos.StatisticDtos;

namespace CaterServ.Services.Abstract
{
    public interface IStatisticService
    {
        Task<List<ResultStatisticDto>> GetAllStatistic();
        Task<ResultStatisticDto> GetStatisticById(string id);
        Task UpdateStatistic(UpdateStatisticDto statisticDto);
        Task CreateStatistic(CreateStatisticDto statisticDto);
        Task DeleteStatistic(string id);
    }
}
