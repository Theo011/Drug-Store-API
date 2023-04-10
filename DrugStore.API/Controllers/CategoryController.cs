using AutoMapper;
using DrugStore.API.Entities;
using DrugStore.API.Models;
using DrugStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DrugStore.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IDrugStoreRepository _repository;
        private readonly IMapper _mapper;

        public CategoryController(IDrugStoreRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var categories = await _repository.GetCategoriesAsync(pageNumber, pageSize);
            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            var paginationMetadata = PaginationMetadata.Create(categories.AsQueryable(), pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(categoryDtos);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _repository.GetCategoryAsync(id);

            if (category == null)
                return NotFound();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryForCreationAndUpdateDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            await _repository.AddCategoryAsync(category);
            await _repository.SaveChangesAsync();

            var createdCategoryDto = _mapper.Map<CategoryDto>(category);

            return CreatedAtRoute("GetCategory", new { id = createdCategoryDto.Id }, createdCategoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryForCreationAndUpdateDto categoryDto)
        {
            var category = await _repository.GetCategoryAsync(id);

            if (category == null)
                return NotFound();

            _mapper.Map(categoryDto, category);
            _repository.UpdateCategory(category);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _repository.GetCategoryAsync(id);

            if (category == null)
                return NotFound();

            _repository.DeleteCategory(category);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}