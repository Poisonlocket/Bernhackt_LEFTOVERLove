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
            Points = createDto.Points,
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
        return OkCustomer(customer);
    }

    private ActionResult<CustomerDto> OkCustomer(Customer? customer) => Ok(_mapper.Map<CustomerDto>(customer));

    /// <summary>Update Customer Points</summary>
    /// <param name="id">Customer ID</param>
    /// <param name="points">New points value</param>
    /// <returns>Updated Customer</returns>
    /// <response code="200">Successful</response>
    /// <response code="404">Customer not found</response>
    [HttpPut("UpdatePoints/{id}")]
    public async Task<ActionResult<CustomerDto>> UpdatePoints(int id, [FromBody] int points)
    {
        var customer = await _dbContext.Customers.FindAsync(id);
        if (customer == null)
            return NotFound();

        customer.Points = points;
        _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync();

        return OkCustomer(customer);
    }

    /// <summary>Add Points to Customer</summary>
    /// <param name="id">Customer ID</param>
    /// <param name="pointsToAdd">Points to add</param>
    /// <returns>Updated Customer</returns>
    /// <response code="200">Successful</response>
    /// <response code="404">Customer not found</response>
    [HttpPost("AddPoints/{id}")]
    public async Task<ActionResult<CustomerDto>> AddPoints(int id, [FromBody] int pointsToAdd)
    {
        var customer = await _dbContext.Customers.FindAsync(id);
        if (customer == null)
            return NotFound();

        customer.Points += pointsToAdd;
        _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync();

        return OkCustomer(customer);
    }
}
