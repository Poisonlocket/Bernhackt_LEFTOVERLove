using AutoMapper;
using LeftOverLove.Common.Dtos;
using LeftOverLove.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeftOverLove.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public CustomerController(
        AppDbContext dbContext,
        IMapper mapper
    )
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>Create new Customer</summary>
    /// <param name="createDto">Dto to create Customer</param>
    /// <return>Created Customer</return>
    /// <response code="200">Successful</response>
    [HttpPost("Create")]
    public async Task<CustomerDto> Create(CreateCustomerDto createDto)
    {
        Customer newCustomer = new()
        {
            FirstName = createDto.FirstName,
            LastName = createDto.LastName,
            Longitude = createDto.Longitude,
            Latitude = createDto.Latitude,
        };
        _dbContext.Customers.Add(newCustomer);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<CustomerDto>(newCustomer);
    }

    /// <summary>Get all Customers</summary>
    /// <returns>List of Customers</returns>
    /// <response code="200">Successful</response>
    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
    {
        var customers = await _dbContext.Customers.ToListAsync();
        return Ok(_mapper.Map<List<CustomerDto>>(customers));
    }

    /// <summary>Get Customer by ID</summary>
    /// <param name="id">Customer ID</param>
    /// <returns>Customer with specified ID</returns>
    /// <response code="200">Successful</response>
    /// <response code="404">Customer not found</response>
    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<CustomerDto>> GetById(int id)
    {
        var customer = await _dbContext.Customers.FindAsync(id);
        if (customer == null)
            return NotFound();
        return Ok(_mapper.Map<CustomerDto>(customer));
    }
}
