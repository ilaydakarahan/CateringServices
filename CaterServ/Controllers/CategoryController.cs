﻿using AutoMapper;
using CaterServ.Dtos.CategoryDtos;
using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		public async  Task<IActionResult> Index()
        {
            var values = await _categoryService.GetAllCategories();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategory(createCategoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCategory(string id)
        {
            var value = await _categoryService.GetCategoryById(id);
            var category = _mapper.Map<UpdateCategoryDto>(value);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategory(updateCategoryDto);
            return RedirectToAction("Index");
        }
    }
}
