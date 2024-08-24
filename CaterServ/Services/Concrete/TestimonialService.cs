using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.TestimonialDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;

namespace CaterServ.Services.Concrete
{
    public class TestimonialService : ITestimonialService

    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMapper _mapper;

        public TestimonialService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
            _mapper = mapper;
        }

        public async Task CreateTestimonial(CreateTestimonialDto testimonailDto)
        {
           var values = _mapper.Map<Testimonial>(testimonailDto);
            await _testimonialCollection.InsertOneAsync(values);
        }

        public async Task DeleteTestimonial(string id)
        {
           await _testimonialCollection.DeleteOneAsync(x=>x.TestimonialId == id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonials()
        {
            var values = await _testimonialCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(values);
        }

        public async Task<ResultTestimonialDto> GetTestimonailById(string id)
        {
            var value = await _testimonialCollection.Find(x=>x.TestimonialId ==id).FirstOrDefaultAsync();
            return _mapper.Map<ResultTestimonialDto>(value);
        }

        public async Task UpdateTestimonial(UpdateTestimonialDto testimonailDto)
        {
            var values = _mapper.Map<Testimonial>(testimonailDto);
            await _testimonialCollection.FindOneAndReplaceAsync(x => x.TestimonialId == values.TestimonialId, values);
        }
    }
}
