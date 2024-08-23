using AutoMapper;
using LeftOverLove.Common.Dtos;
using LeftOverLove.Common.Entities;
using LeftOverLove.DataAccess;
using LeftOverLove.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
}
