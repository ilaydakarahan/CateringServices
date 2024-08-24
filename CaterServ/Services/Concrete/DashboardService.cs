using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.DashboardDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;

namespace CaterServ.Services.Concrete
{
    public class DashboardService : IDashboardService
    {
        private readonly IMongoCollection<Message> _messageCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Booking> _bookingCollection;
        private readonly IMongoCollection<Event> _eventCollection;

        public DashboardService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _messageCollection = database.GetCollection<Message>(databaseSettings.MessageCollectionName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _bookingCollection = database.GetCollection<Booking>(databaseSettings.BookingCollectionName);
            _eventCollection = database.GetCollection<Event>(databaseSettings.EventCollectionName);           
        }

        public ResultDashboardDto GetDashboardAll()
        {
            ResultDashboardDto resultDashboardDto = new ResultDashboardDto()
            {
                BookingCount = _bookingCollection.AsQueryable().Count(),
                CategoryCount = _categoryCollection.AsQueryable().Count(),
                ProductCount = _productCollection.AsQueryable().Count(),
                MessageCount = _messageCollection.AsQueryable().Count(),
                EventCount = _eventCollection.AsQueryable().Count()
            };

            return resultDashboardDto;
        }
    }
}
