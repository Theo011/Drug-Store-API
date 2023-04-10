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
    [Route("api/v{version:apiVersion}/products")]
    public class ProductController : ControllerBase
    {
        private readonly IDrugStoreRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IDrugStoreRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var products = await _repository.GetProductsAsync(pageNumber, pageSize);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            var paginationMetadata = PaginationMetadata.Create(products.AsQueryable(), pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(productDtos);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _repository.GetProductAsync(id);

            if (product == null)
                return NotFound();

            var productDto = _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductForCreationAndUpdateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            await _repository.AddProductAsync(product);
            await _repository.SaveChangesAsync();

            var createdProductDto = _mapper.Map<ProductDto>(product);

            return CreatedAtRoute("GetProduct", new { id = createdProductDto.Id }, createdProductDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductForCreationAndUpdateDto productDto)
        {
            var product = await _repository.GetProductAsync(id);

            if (product == null)
                return NotFound();

            _mapper.Map(productDto, product);
            _repository.UpdateProduct(product);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _repository.GetProductAsync(id);

            if (product == null)
                return NotFound();

            _repository.DeleteProduct(product);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}