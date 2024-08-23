using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.ProductDtos;

namespace CaterServ.Mapping
{
	public class ProductMapping : Profile
	{
        public ProductMapping()
        {
            CreateMap<Product, ResultProductDto>().ReverseMap();    
            CreateMap<Product, CreateProductDto>().ReverseMap();    
            CreateMap<Product, UpdateProductDto>().ReverseMap();      
            CreateMap<ResultProductDto, UpdateProductDto>().ReverseMap();      
        }
    }
}
