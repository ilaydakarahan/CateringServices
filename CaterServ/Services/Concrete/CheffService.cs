using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.CheffDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;

namespace CaterServ.Services.Concrete
{
    public class CheffService : ICheffService
    {
        private readonly IMongoCollection<Cheff> _cheffCollection;
        private readonly IMapper _mapper;

        public CheffService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _cheffCollection = database.GetCollection<Cheff>(databaseSettings.CheffCollectionName);
            _mapper = mapper;

        }

        public async Task CreateCheff(CreateCheffDto createCheffdto)
        {
            var values = _mapper.Map<Cheff>(createCheffdto);
            await _cheffCollection.InsertOneAsync(values);
        }

        public async Task DeleteCheff(string id)
        {
            await _cheffCollection.DeleteOneAsync(x=>x.CheffId == id);
        }
        public async Task<ResultCheffDto> GetCheffById(string id)
        {
            var value = await _cheffCollection.Find(x => x.CheffId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultCheffDto>(value);
        }

        public async Task<List<ResultCheffDto>> GetAllCheffs()
        {
            var values = await _cheffCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultCheffDto>>(values);
        }


        public async Task UpdateCheff(UpdateCheffDto updateCheffdto)
        {
            var values = _mapper.Map<Cheff>(updateCheffdto);
            await _cheffCollection.FindOneAndReplaceAsync(x => x.CheffId == values.CheffId, values);
        }
    }
}
