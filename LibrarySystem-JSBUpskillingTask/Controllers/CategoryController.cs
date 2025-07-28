using LibrarySystem.Core.DTOs;
using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem_JSBUpskillingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            if (categories == null || !categories.Any())
                return NotFound("No categories found.");
            var categoryDtos = categories.Select(c => new CategoryDto()
            {
                CategoryId = c.CategoryId,
                Description = c.Description,
                Name = c.Name
            }).ToList();

            return Ok(categoryDtos);
        }

        [HttpGet("id")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
                return NotFound("Category not found.");

            var categoryDto = new CategoryDto()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description

            };

            return Ok(categoryDto); 

        }
        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryDto categoryData)
        {
            if (categoryData.CategoryId <= 0)
                return BadRequest("Invalid CategoryId.");
            var existingCategory = _categoryRepository.GetById(categoryData.CategoryId);
            if (existingCategory != null)
                return BadRequest("Category with this ID already exists.");

            if (ModelState.IsValid)
            {
                Category category = new()
                {
                    Name = categoryData.Name,
                    Description = categoryData.Description
                };
                _categoryRepository.Add(category);

                return Ok(category);

            }
            return BadRequest("Invalid data provided for category.");
        }
        [HttpPut]
        public IActionResult UpdateCategory([FromBody] CategoryDto categoryDto)
        {
            if(categoryDto.CategoryId <= 0)
                return BadRequest("Invalid CategotyId.");

            var category = _categoryRepository.GetById(categoryDto.CategoryId);
            if (category == null)
                return NotFound("Category not found.");

            if (ModelState.IsValid)
            {
                category.Name = categoryDto.Name;
                category.Description = categoryDto.Description;
                _categoryRepository.Update(category);
                
            }
            return Ok(category);
        }
        [HttpDelete("id")]
        public IActionResult Detetecategory(int categoryId)
        {
            if (categoryId <= 0)
                return BadRequest("Invalid Category ID.");

            var category = _categoryRepository.GetById(categoryId , a => a.Books);
            if (category == null )
                return NotFound("Category not found.");
            else if (category.Books != null && category.Books.Any())
                return BadRequest("Category cannot be deleted because it has associated books.");

            _categoryRepository.Delete(categoryId);
            return Ok("Category deleted successfully.");
        }
    }
}
