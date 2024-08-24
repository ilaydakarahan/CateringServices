using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.FeatureDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;

namespace CaterServ.Services.Concrete
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeature(CreateFeatureDto createfeatureDto)
        {
            var value = _mapper.Map<Feature>(createfeatureDto);
            await _featureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeature(string id)
        {
            await _featureCollection.DeleteOneAsync(x=>x.FeatureId == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatures()
        {
            var values = await _featureCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<ResultFeatureDto> GetFeatureById(string id)
        {
            var value = await _featureCollection.Find(x=>x.FeatureId ==id).FirstOrDefaultAsync();
            return _mapper.Map<ResultFeatureDto>(value);
        }

        public async Task UpdateFeature(UpdateFeatureDto updatefeatureDto)
        {
            var values = _mapper.Map<Feature>(updatefeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == values.FeatureId, values);
        }
    }
}
