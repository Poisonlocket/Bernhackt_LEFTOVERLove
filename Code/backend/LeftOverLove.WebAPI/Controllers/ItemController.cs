using AutoMapper;
using LeftOverLove.Common.Dtos;
using LeftOverLove.Common.Entities;
using LeftOverLove.Common.Enums;
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
            State = ItemState.Ready,
            CreationDate = DateTime.UtcNow,
            CustomerId = createDto.CustomerId,
        };
        _dbContext.Items.Add(newItem);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<ItemDto>(newItem);
    }

    /// <summary>Create multiple new Items</summary>
    /// <param name="createDto">Dto to create Items</param>
    /// <return>Created Items</return>
    /// <response code="200">Successful</response>
    [HttpPost("CreateBulk")]
    public async Task<IEnumerable<ItemDto>> CreateBulk(IEnumerable<CreateItemDto> createDtos)
    {
        List<Item> result = new();

        foreach (CreateItemDto createDto in createDtos)
        {
            Item newItem = new()
            {
                Description = createDto.Description,
                Longitude = createDto.Longitude,
                Latitude = createDto.Latitude,
                ExpirationDate = createDto.ExpirationDate,
                State = ItemState.Ready,
                CreationDate = DateTime.UtcNow,
                CustomerId = 1
            };
            _dbContext.Items.Add(newItem);
            result.Add(newItem);
        }
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<IEnumerable<ItemDto>>(result);
    }

    [HttpPost("AddPictures")]
    public async Task AddPictures(IFormFileCollection pictures, [FromQuery] int itemId)
    {
        await this._itemService.AddPictures(pictures, itemId);
    }

    [HttpGet("All")]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetAll()
    {
        IEnumerable<Item> items = await _dbContext.Items
                                    .Include(item => item.Customer)
                                    .ToListAsync();
        return Ok(_mapper.Map<IEnumerable<ItemDto>>(items));
    }

    [HttpGet("Range")]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetRange(int skip, int? take, double longitude, double latitude)
    {
        IEnumerable<Item> items = await _itemService.GetRange(skip, take, longitude, latitude);

        return Ok(_mapper.Map<IEnumerable<ItemDto>>(items));
    }

    [HttpGet("ById/{id}")]
    public async Task<ActionResult<ItemDto>> GetById(int id)
    {
        Item? item = await _dbContext.Items
            .Include(i => i.Customer)
            .FirstOrDefaultAsync(i => i.Id == id);

        if (item == null)
            return NotFound();

        return Ok(_mapper.Map<ItemDto>(item));
    }
}
