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
    [Route("api/v{version:apiVersion}/productinvoices")]
    public class ProductInvoiceController : ControllerBase
    {
        private readonly IDrugStoreRepository _repository;
        private readonly IMapper _mapper;

        public ProductInvoiceController(IDrugStoreRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInvoiceDto>>> GetProductInvoices([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var productInvoices = await _repository.GetProductInvoicesAsync(pageNumber, pageSize);
            var productInvoiceDtos = _mapper.Map<IEnumerable<ProductInvoiceDto>>(productInvoices);
            var paginationMetadata = PaginationMetadata.Create(productInvoices.AsQueryable(), pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(productInvoiceDtos);
        }

        [HttpGet("invoice/{invoiceId}/product/{productId}", Name = "GetProductInvoice")]
        public async Task<ActionResult<ProductInvoiceDto>> GetProductInvoice(int invoiceId, int productId)
        {
            var productInvoice = await _repository.GetProductInvoiceAsync(invoiceId, productId);

            if (productInvoice == null)
                return NotFound();

            var productInvoiceDto = _mapper.Map<ProductInvoiceDto>(productInvoice);

            return Ok(productInvoiceDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductInvoiceDto>> CreateProductInvoice(ProductInvoiceForCreationAndUpdateDto productInvoiceDto)
        {
            var productInvoice = _mapper.Map<ProductInvoice>(productInvoiceDto);

            await _repository.AddProductInvoiceAsync(productInvoice);
            await _repository.SaveChangesAsync();

            var createdProductInvoiceDto = _mapper.Map<ProductInvoiceDto>(productInvoice);

            return CreatedAtRoute("GetProductInvoice", new { invoiceId = createdProductInvoiceDto.InvoiceId, productId = createdProductInvoiceDto.ProductId }, createdProductInvoiceDto);
        }

        [HttpPut("invoice/{invoiceId}/product/{productId}")]
        public async Task<IActionResult> UpdateProductInvoice(int invoiceId, int productId, ProductInvoiceForCreationAndUpdateDto productInvoiceDto)
        {
            var productInvoice = await _repository.GetProductInvoiceAsync(invoiceId, productId);

            if (productInvoice == null)
                return NotFound();

            _mapper.Map(productInvoiceDto, productInvoice);
            _repository.UpdateProductInvoice(productInvoice);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("invoice/{invoiceId}/product/{productId}")]
        public async Task<IActionResult> DeleteProductInvoice(int invoiceId, int productId)
        {
            var productInvoice = await _repository.GetProductInvoiceAsync(invoiceId, productId);

            if (productInvoice == null)
                return NotFound();

            _repository.DeleteProductInvoice(productInvoice);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}