using CaterServ.Dtos.ProductDtos;

namespace CaterServ.Services.Abstract
{
	public interface IProductService
	{
		Task<List<ResultProductDto>> GetAllProducts();
		Task<ResultProductDto> GetProductById(string id);
		Task UpdateProduct(UpdateProductDto productDto);
		Task CreateProduct(CreateProductDto productDto);
		Task DeleteProduct(string id);

	}
}
