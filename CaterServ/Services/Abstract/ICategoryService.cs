using CaterServ.Dtos.CategoryDtos;

namespace CaterServ.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategories();
        Task<ResultCategoryDto> GetCategoryById(string id);
        Task UpdateCategory(UpdateCategoryDto categoryDto);
        Task CreateCategory(CreateCategoryDto categoryDto);
        Task DeleteCategory(string id);

    }
}
