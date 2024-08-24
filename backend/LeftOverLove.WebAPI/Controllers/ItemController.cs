using AutoMapper;
using LeftOverLove.Common.Dtos;
using LeftOverLove.Common.Entities;
using LeftOverLove.DataAccess;
using LeftOverLove.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeftOverLove.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ItemService _itemService;

    public ItemController(
        AppDbContext dbContext,
        IMapper mapper,
        ItemService itemService
    )
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _itemService = itemService;
    }

    /// <summary>Create new Item</summary>
    /// <param name="createDto">Dto to create Item</param>
    /// <return>Created Item</return>
    /// <response code="200">Successful</response>
    [HttpPost("Create")]
    public async Task<ItemDto> Create(CreateItemDto createDto)
    {
        Item newItem = new()
        {
            Description = createDto.Description,
            Longitude = createDto.Longitude,
            Latitude = createDto.Latitude,
            ExpirationDate = createDto.ExpirationDate,
            State = createDto.State,
            CreationDate = createDto.CreationDate,
            CustomerId = createDto.CustomerId,
        };
        _dbContext.Items.Add(newItem);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<ItemDto>(newItem);
    }

    [HttpPost("AddPictures")]
    public async Task AddPictures(IFormFileCollection pictures, [FromQuery] int itemId)
    {
        await this._itemService.AddPictures(pictures, itemId);
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetAll()
    {
        var items = await _dbContext.Items
                                    .Include(item => item.Customer)
                                    .ToListAsync();
        return Ok(_mapper.Map<List<ItemDto>>(items));
    }


    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<ItemDto>> GetById(int id)
    {
        var customer = await _dbContext.Items.FindAsync(id);
        
        if (customer == null)
            return NotFound();
        customer.Customer = await _dbContext.Customers.FindAsync(customer.CustomerId);
        return Ok(_mapper.Map<ItemDto>(customer));
    }
}
