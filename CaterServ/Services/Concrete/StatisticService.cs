using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.StatisticDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;

namespace CaterServ.Services.Concrete
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Statistic> _statisticCollection;
        private readonly IMapper _mapper;

        public StatisticService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _statisticCollection = database.GetCollection<Statistic>(databaseSettings.StatisticCollectionName);
            _mapper = mapper;
        }

        public async Task CreateStatistic(CreateStatisticDto statisticDto)
        {
            var values = _mapper.Map<Statistic>(statisticDto);  
            await _statisticCollection.InsertOneAsync(values);
        }

        public async Task DeleteStatistic(string id)
        {
            await _statisticCollection.DeleteOneAsync(x=>x.StatisticId == id);
        }

        public async Task<List<ResultStatisticDto>> GetAllStatistic()
        {
            var values = await _statisticCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultStatisticDto>>(values);
        }

        public async Task<ResultStatisticDto> GetStatisticById(string id)
        {
            var value = await _statisticCollection.Find(x=>x.StatisticId ==id).FirstOrDefaultAsync();
            return _mapper.Map<ResultStatisticDto>(value);
        }

        public async Task UpdateStatistic(UpdateStatisticDto statisticDto)
        {
            var value = _mapper.Map<Statistic>(statisticDto);
            await _statisticCollection.FindOneAndReplaceAsync(x => x.StatisticId == value.StatisticId, value);
        }
    }
}
