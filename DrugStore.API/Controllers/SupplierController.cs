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
    [Route("api/v{version:apiVersion}/suppliers")]
    public class SupplierController : ControllerBase
    {
        private readonly IDrugStoreRepository _repository;
        private readonly IMapper _mapper;

        public SupplierController(IDrugStoreRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var suppliers = await _repository.GetSuppliersAsync(pageNumber, pageSize);
            var supplierDtos = _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
            var paginationMetadata = PaginationMetadata.Create(suppliers.AsQueryable(), pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(supplierDtos);
        }

        [HttpGet("{id}", Name = "GetSupplier")]
        public async Task<ActionResult<SupplierDto>> GetSupplier(int id)
        {
            var supplier = await _repository.GetSupplierAsync(id);

            if (supplier == null)
                return NotFound();

            var supplierDto = _mapper.Map<SupplierDto>(supplier);

            return Ok(supplierDto);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDto>> CreateSupplier(SupplierForCreationAndUpdateDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);

            await _repository.AddSupplierAsync(supplier);
            await _repository.SaveChangesAsync();

            var createdSupplierDto = _mapper.Map<SupplierDto>(supplier);

            return CreatedAtRoute("GetSupplier", new { id = createdSupplierDto.Id }, createdSupplierDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, SupplierForCreationAndUpdateDto supplierDto)
        {
            var supplier = await _repository.GetSupplierAsync(id);

            if (supplier == null)
                return NotFound();

            _mapper.Map(supplierDto, supplier);
            _repository.UpdateSupplier(supplier);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _repository.GetSupplierAsync(id);

            if (supplier == null)
                return NotFound();

            _repository.DeleteSupplier(supplier);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}