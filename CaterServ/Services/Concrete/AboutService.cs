using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.AboutDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;

namespace CaterServ.Services.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAbout(CreateAboutDto aboutDto)
        {
            var values = _mapper.Map<About>(aboutDto);
            await _aboutCollection.InsertOneAsync(values);
        }

        public async Task DeleteAbout(string id)
        {
            await _aboutCollection.DeleteOneAsync(x=>x.AboutId == id);
        }

        public async Task<ResultAboutDto> GetAboutById(string id)
        {
            var value = await _aboutCollection.Find(x=>x.AboutId==id).FirstOrDefaultAsync();
            return _mapper.Map<ResultAboutDto>(value);
        }

        public async Task<List<ResultAboutDto>> GetAllAbouts()
        {
            var values = await _aboutCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task UpdateAbout(UpdateAboutDto aboutDto)
        {
            var values = _mapper.Map<About>(aboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(x=>x.AboutId == values.AboutId , values);
        }
    }
}
