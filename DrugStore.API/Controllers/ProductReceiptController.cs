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
    [Route("api/v{version:apiVersion}/productreceipts")]
    public class ProductReceiptController : ControllerBase
    {
        private readonly IDrugStoreRepository _repository;
        private readonly IMapper _mapper;

        public ProductReceiptController(IDrugStoreRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReceiptDto>>> GetProductReceipts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var productReceipts = await _repository.GetProductReceiptsAsync(pageNumber, pageSize);
            var productReceiptDtos = _mapper.Map<IEnumerable<ProductReceiptDto>>(productReceipts);
            var paginationMetadata = PaginationMetadata.Create(productReceipts.AsQueryable(), pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(productReceiptDtos);
        }

        [HttpGet("receipt/{receiptId}/product/{productId}", Name = "GetProductReceipt")]
        public async Task<ActionResult<ProductReceiptDto>> GetProductReceipt(int receiptId, int productId)
        {
            var productReceipt = await _repository.GetProductReceiptAsync(receiptId, productId);

            if (productReceipt == null)
                return NotFound();

            var productReceiptDto = _mapper.Map<ProductReceiptDto>(productReceipt);

            return Ok(productReceiptDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductReceiptDto>> CreateProductReceipt(ProductReceiptForCreationAndUpdateDto productReceiptDto)
        {
            var productReceipt = _mapper.Map<ProductReceipt>(productReceiptDto);

            await _repository.AddProductReceiptAsync(productReceipt);
            await _repository.SaveChangesAsync();

            var createdProductReceiptDto = _mapper.Map<ProductReceiptDto>(productReceipt);

            return CreatedAtRoute("GetProductReceipt", new { receiptId = createdProductReceiptDto.ReceiptId, productId = createdProductReceiptDto.ProductId }, createdProductReceiptDto);
        }

        [HttpPut("receipt/{receiptId}/product/{productId}")]
        public async Task<IActionResult> UpdateProductReceipt(int receiptId, int productId, ProductReceiptForCreationAndUpdateDto productReceiptDto)
        {
            var productReceipt = await _repository.GetProductReceiptAsync(receiptId, productId);

            if (productReceipt == null)
                return NotFound();

            _mapper.Map(productReceiptDto, productReceipt);
            _repository.UpdateProductReceipt(productReceipt);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("receipt/{receiptId}/product/{productId}")]
        public async Task<IActionResult> DeleteProductReceipt(int receiptId, int productId)
        {
            var productReceipt = await _repository.GetProductReceiptAsync(receiptId, productId);

            if (productReceipt == null)
                return NotFound();

            _repository.DeleteProductReceipt(productReceipt);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}