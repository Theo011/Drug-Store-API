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
    [Route("api/v{version:apiVersion}/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly IDrugStoreRepository _repository;
        private readonly IMapper _mapper;

        public CustomerController(IDrugStoreRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var customers = await _repository.GetCustomersAsync(pageNumber, pageSize);
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            var paginationMetadata = PaginationMetadata.Create(customers.AsQueryable(), pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(customerDtos);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await _repository.GetCustomerAsync(id);

            if (customer == null)
                return NotFound();

            var customerDto = _mapper.Map<CustomerDto>(customer);

            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerForCreationAndUpdateDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            await _repository.AddCustomerAsync(customer);
            await _repository.SaveChangesAsync();

            var createdCustomerDto = _mapper.Map<CustomerDto>(customer);

            return CreatedAtRoute("GetCustomer", new { id = createdCustomerDto.Id }, createdCustomerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerForCreationAndUpdateDto customerDto)
        {
            var customer = await _repository.GetCustomerAsync(id);

            if (customer == null)
                return NotFound();

            _mapper.Map(customerDto, customer);
            _repository.UpdateCustomer(customer);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _repository.GetCustomerAsync(id);

            if (customer == null)
                return NotFound();

            _repository.DeleteCustomer(customer);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}