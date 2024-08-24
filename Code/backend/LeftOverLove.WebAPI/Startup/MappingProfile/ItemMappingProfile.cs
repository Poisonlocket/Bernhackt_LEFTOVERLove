using AutoMapper;
using LeftOverLove.Common.Dtos;
using LeftOverLove.Common.Entities;

namespace LeftOverLove.WebAPI.Startup.MappingProfile;

public class ItemMappingProfile : Profile
{
    public ItemMappingProfile()
    {
        // CreateMap<TSrc, TDest>();
        CreateMap<Item, ItemDto>();
    }
}
