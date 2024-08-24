using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.ContactDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;

namespace CaterServ.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContact(CreateContactDto createContactdto)
        {
            var values = _mapper.Map<Contact>(createContactdto);
            await _contactCollection.InsertOneAsync(values);
        }

        public async Task DeleteContact(string id)
        {
            await _contactCollection.DeleteOneAsync(x=>x.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContact()
        {
            var values = await _contactCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<ResultContactDto> GetContactById(string id)
        {
            var value = await _contactCollection.Find(x=>x.ContactId==id).FirstOrDefaultAsync();
            return _mapper.Map<ResultContactDto>(value);
        }

        public async Task UpdateContact(UpdateContactDto updateContact)
        {
            var values = _mapper.Map<Contact>(updateContact);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == values.ContactId, values);
        }
    }
}
