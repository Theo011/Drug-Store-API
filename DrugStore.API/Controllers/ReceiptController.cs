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
    [Route("api/v{version:apiVersion}/receipts")]
    public class ReceiptController : ControllerBase
    {
        private readonly IDrugStoreRepository _repository;
        private readonly IMapper _mapper;

        public ReceiptController(IDrugStoreRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptDto>>> GetReceipts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var receipts = await _repository.GetReceiptsAsync(pageNumber, pageSize);
            var receiptDtos = _mapper.Map<IEnumerable<ReceiptDto>>(receipts);
            var paginationMetadata = PaginationMetadata.Create(receipts.AsQueryable(), pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(receiptDtos);
        }

        [HttpGet("{id}", Name = "GetReceipt")]
        public async Task<ActionResult<ReceiptDto>> GetReceipt(int id)
        {
            var receipt = await _repository.GetReceiptAsync(id);

            if (receipt == null)
                return NotFound();

            var receiptDto = _mapper.Map<ReceiptDto>(receipt);

            return Ok(receiptDto);
        }

        [HttpPost]
        public async Task<ActionResult<ReceiptDto>> CreateReceipt(ReceiptForCreationAndUpdateDto receiptDto)
        {
            var receipt = _mapper.Map<Receipt>(receiptDto);

            await _repository.AddReceiptAsync(receipt);
            await _repository.SaveChangesAsync();

            var createdReceiptDto = _mapper.Map<ReceiptDto>(receipt);

            return CreatedAtRoute("GetReceipt", new { id = createdReceiptDto.Id }, createdReceiptDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReceipt(int id, ReceiptForCreationAndUpdateDto receiptDto)
        {
            var receipt = await _repository.GetReceiptAsync(id);

            if (receipt == null)
                return NotFound();

            _mapper.Map(receiptDto, receipt);
            _repository.UpdateReceipt(receipt);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceipt(int id)
        {
            var receipt = await _repository.GetReceiptAsync(id);

            if (receipt == null)
                return NotFound();

            _repository.DeleteReceipt(receipt);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}