using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.MessageDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;

namespace CaterServ.Services.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMongoCollection<Message> _messageCollection;
        private readonly IMapper _mapper;

        public MessageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _messageCollection = database.GetCollection<Message>(databaseSettings.MessageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateMessage(CreateMessageDto MessageDto)
        {
            var values = _mapper.Map<Message>(MessageDto);
            await _messageCollection.InsertOneAsync(values);
        }

        public async Task DeleteMessage(string id)
        {
            await _messageCollection.DeleteOneAsync(x=>x.MessageId == id);
        }

        public async Task<List<ResultMessageDto>> GetAllMessages()
        {
            var values = await _messageCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<ResultMessageDto> GetMessageById(string id)
        {
            var value = await _messageCollection.Find(x=>x.MessageId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultMessageDto>(value);
        }
    }
}
