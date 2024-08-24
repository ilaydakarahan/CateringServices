using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.EventCategoryDtos;
using CaterServ.Dtos.EventDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;

namespace CaterServ.Services.Concrete
{
    public class EventService : IEventService
    {
        private readonly IMongoCollection<Event> _eventCollection;
        private readonly IMapper _mapper;
        public EventService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _eventCollection = database.GetCollection<Event>(databaseSettings.EventCollectionName);
            _mapper = mapper;
        }

        public async Task CreateEvent(CreateEventDto eventDto)
        {
            var values = _mapper.Map<Event>(eventDto);
            await _eventCollection.InsertOneAsync(values);
        }

        public async Task DeleteEvent(string id)
        {
           await _eventCollection.DeleteOneAsync(x=>x.EventId == id);
        }

        public async Task<List<ResultEventDto>> GetAllEvents()
        {
            var values = await _eventCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultEventDto>>(values);
        }

        public async Task<ResultEventDto> GetEventById(string id)
        {
            var value = await _eventCollection.Find(x=>x.EventId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultEventDto>(value);
        }

        public async Task<List<ResultEventDto>> GetEventsAndCategories()
        {
            //Etkinlikleri kategorileriyle birlikte listeleme metodu
            var events = await _eventCollection.AsQueryable().ToListAsync();
            List<ResultEventDto> results = new List<ResultEventDto>();
            foreach (var item in events)
            {
                var categories = _eventCollection.Find(x => x.EventCategoryId == item.EventCategoryId).FirstOrDefault();
                if(categories != null)
                {
                    var mapped = _mapper.Map<ResultEventCategoryDto>(categories);
                    results.Add(new ResultEventDto
                    {
                        EventCategoryId = item.EventCategoryId,
                        EventId = item.EventId,
                        EventCategory = mapped,
                        ImageUrl = item.ImageUrl
                    });               
                }
            }
            return results;
        }

        public async Task UpdateEvent(UpdateEventDto eventDto)
        {
            var values = _mapper.Map<Event>(eventDto);
            await _eventCollection.FindOneAndReplaceAsync(x => x.EventId == values.EventId, values);

        }
    }
}
