using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.ServiceDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;

namespace CaterServ.Services.Concrete
{
    public class ServicesService : IServicesService
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        private readonly IMapper _mapper;

        public ServicesService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
            _mapper = mapper;
        }

        public async Task CreateService(CreateServiceDto createServiceDto)
        {
            var value = _mapper.Map<Service>(createServiceDto);
            await _serviceCollection.InsertOneAsync(value);
        }

        public async Task DeleteService(string id)
        {
            await _serviceCollection.DeleteOneAsync(x=>x.ServiceId == id);
        }

        public async Task<List<ResultServiceDto>> GetAllServices()
        {
            var values = await _serviceCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultServiceDto>>(values);
        }

        public async Task<ResultServiceDto> GetServiceById(string id)
        {
            var value = await _serviceCollection.Find(x=>x.ServiceId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultServiceDto>(value);
        }

        public async Task UpdateService(UpdateServiceDto updateServiceDto)
        {
            var values = _mapper.Map<Service>(updateServiceDto);
            await _serviceCollection.FindOneAndReplaceAsync(x=>x.ServiceId == values.ServiceId , values)
        }
    }
}
