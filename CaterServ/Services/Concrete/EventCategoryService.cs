using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.EventCategoryDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;

namespace CaterServ.Services.Concrete
{
    public class EventCategoryService : IEventCategoryService
    {
        private readonly IMongoCollection<EventCategory> _eventCategoryCollection;
        private readonly IMapper _mapper;

        public EventCategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _eventCategoryCollection = database.GetCollection<EventCategory>(databaseSettings.EventCategoryCollectionName);


            _mapper = mapper;
        }

        public async Task CreateEventCategory(CreateEventCategoryDto eventCategoryDto)
        {
            var values = _mapper.Map<EventCategory>(eventCategoryDto);
            await _eventCategoryCollection.InsertOneAsync(values);
        }

        public async Task DeleteEventCategory(string id)
        {
           await _eventCategoryCollection.DeleteOneAsync(x=>x.EventCategoryId == id);
        }

        public async Task<List<ResultEventCategoryDto>> GetAllEventCategory()
        {
            var values = await _eventCategoryCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultEventCategoryDto>>(values);
        }

        public async Task<ResultEventCategoryDto> GetEventCategoryById(string id)
        {
            var value = await _eventCategoryCollection.Find(x => x.EventCategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultEventCategoryDto>(value);
        }

        public async Task UpdateEventCategory(UpdateEventCategoryDto eventCategoryDto)
        {
            var values = _mapper.Map<EventCategory>(eventCategoryDto);
            await _eventCategoryCollection.FindOneAndReplaceAsync(x => x.EventCategoryId == values.EventCategoryId, values);
        }
    }
}
