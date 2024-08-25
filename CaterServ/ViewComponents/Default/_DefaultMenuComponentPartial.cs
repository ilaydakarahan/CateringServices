using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Default
{
    public class _DefaultMenuComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public _DefaultMenuComponentPartial(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _productService.GetProductAndCategories();
            ViewBag.Categories = await _categoryService.GetAllCategories();
            return View(value);
        }
    }
}
