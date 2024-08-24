using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.BookingDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CaterServ.Services.Concrete
{
    public class BookingService : IBookingService
    {
        private readonly IMongoCollection<Booking> _bookingCollection;
        private readonly IMapper _mapper;

        public BookingService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bookingCollection = database.GetCollection<Booking>(databaseSettings.BookingCollectionName);
            _mapper = mapper;

        }

        public async Task CreateBooking(CreateBookingDto createBookingDto)
        {
            var values = _mapper.Map<Booking>(createBookingDto);
            await _bookingCollection.InsertOneAsync(values);
        }

        public async Task DeleteBooking(string id)
        {
            await _bookingCollection.DeleteOneAsync(x=>x.BookingId == id);
        }

        public async Task<List<ResultBookingDto>> GetAllBookings()
        {
            var values = await _bookingCollection.AsQueryable().OrderByDescending(x=>x.BookingId).ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(values);
        }

        public async Task<ResultBookingDto> GetBookingById(string id)
        {
            var value = await _bookingCollection.Find(x=>x.BookingId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultBookingDto>(value);
        }

        public async Task<List<ResultBookingDto>> SearchBooking(string nameSurname)
        {
            var value = await _bookingCollection.AsQueryable().Where(x=>x.NameSurname == nameSurname).ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(value);
        }

        public async Task UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var values = _mapper.Map<Booking>(updateBookingDto);
            await _bookingCollection.FindOneAndReplaceAsync(x => x.BookingId == values.BookingId, values);
        }
    }
}
