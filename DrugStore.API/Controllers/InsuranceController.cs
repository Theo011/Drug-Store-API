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
    [Route("api/v{version:apiVersion}/insurances")]
    public class InsuranceController : ControllerBase
    {
        private readonly IDrugStoreRepository _repository;
        private readonly IMapper _mapper;

        public InsuranceController(IDrugStoreRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceDto>>> GetInsurances([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var insurances = await _repository.GetInsurancesAsync(pageNumber, pageSize);
            var insuranceDtos = _mapper.Map<IEnumerable<InsuranceDto>>(insurances);
            var paginationMetadata = PaginationMetadata.Create(insurances.AsQueryable(), pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(insuranceDtos);
        }

        [HttpGet("{id}", Name = "GetInsurance")]
        public async Task<ActionResult<InsuranceDto>> GetInsurance(int id)
        {
            var insurance = await _repository.GetInsuranceAsync(id);

            if (insurance == null)
                return NotFound();

            var insuranceDto = _mapper.Map<InsuranceDto>(insurance);

            return Ok(insuranceDto);
        }

        [HttpPost]
        public async Task<ActionResult<InsuranceDto>> CreateInsurance(InsuranceForCreationAndUpdateDto insuranceDto)
        {
            var insurance = _mapper.Map<Insurance>(insuranceDto);

            await _repository.AddInsuranceAsync(insurance);
            await _repository.SaveChangesAsync();

            var createdInsuranceDto = _mapper.Map<InsuranceDto>(insurance);

            return CreatedAtRoute("GetInsurance", new { id = createdInsuranceDto.Id }, createdInsuranceDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInsurance(int id, InsuranceForCreationAndUpdateDto insuranceDto)
        {
            var insurance = await _repository.GetInsuranceAsync(id);

            if (insurance == null)
                return NotFound();

            _mapper.Map(insuranceDto, insurance);
            _repository.UpdateInsurance(insurance);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {
            var insurance = await _repository.GetInsuranceAsync(id);

            if (insurance == null)
                return NotFound();

            _repository.DeleteInsurance(insurance);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}