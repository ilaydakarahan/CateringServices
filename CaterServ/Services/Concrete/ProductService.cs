using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.ProductDtos;
using CaterServ.Services.Abstract;
using CaterServ.Settings;
using MongoDB.Driver;

namespace CaterServ.Services.Concrete
{
	public class ProductService : IProductService
	{
		private readonly IMongoCollection<Product> _productCollection;
		private readonly IMapper _mapper;

		public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			_mapper = mapper;
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
			//productcollectionname veritabanına product sınıfını adını çoğul yazar
		}

		public async Task CreateProduct(CreateProductDto productDto)
		{
			var product = _mapper.Map<Product>(productDto);
			await _productCollection.InsertOneAsync(product);
		}

		public async Task DeleteProduct(string id)
		{
			await _productCollection.DeleteOneAsync(x=>x.ProductId == id);
		}

		public async Task<List<ResultProductDto>> GetAllProducts()
		{
			var values = await _productCollection.AsQueryable().ToListAsync();
			return _mapper.Map<List<ResultProductDto>>(values);
		}

		public async Task<ResultProductDto> GetProductById(string id)
		{
			var value = await _productCollection.Find(x=>x.ProductId == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultProductDto>(value);
		}

		public async Task UpdateProduct(UpdateProductDto productDto)
		{
			var product = _mapper.Map<Product>(productDto);		//product nesnesine product dto' u mapledik.
			await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId == product.ProductId, product);
			//Önce bul sonra değiştir, product nesnesinden gelen id ye eşit olanı bul ve bunu product'tan gelen değer ile değiştir.
		}
	}
}
