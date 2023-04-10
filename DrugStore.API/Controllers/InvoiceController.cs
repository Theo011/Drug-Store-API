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
    [Route("api/v{version:apiVersion}/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IDrugStoreRepository _repository;
        private readonly IMapper _mapper;

        public InvoiceController(IDrugStoreRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetInvoices([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var invoices = await _repository.GetInvoicesAsync(pageNumber, pageSize);
            var invoiceDtos = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
            var paginationMetadata = PaginationMetadata.Create(invoices.AsQueryable(), pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(invoiceDtos);
        }

        [HttpGet("{id}", Name = "GetInvoice")]
        public async Task<ActionResult<InvoiceDto>> GetInvoice(int id)
        {
            var invoice = await _repository.GetInvoiceAsync(id);

            if (invoice == null)
                return NotFound();

            var invoiceDto = _mapper.Map<InvoiceDto>(invoice);

            return Ok(invoiceDto);
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceDto>> CreateInvoice(InvoiceForCreationAndUpdateDto invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);

            await _repository.AddInvoiceAsync(invoice);
            await _repository.SaveChangesAsync();

            var createdInvoiceDto = _mapper.Map<InvoiceDto>(invoice);

            return CreatedAtRoute("GetInvoice", new { id = createdInvoiceDto.Id }, createdInvoiceDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, InvoiceForCreationAndUpdateDto invoiceDto)
        {
            var invoice = await _repository.GetInvoiceAsync(id);

            if (invoice == null)
                return NotFound();

            _mapper.Map(invoiceDto, invoice);
            _repository.UpdateInvoice(invoice);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await _repository.GetInvoiceAsync(id);

            if (invoice == null)
                return NotFound();

            _repository.DeleteInvoice(invoice);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}