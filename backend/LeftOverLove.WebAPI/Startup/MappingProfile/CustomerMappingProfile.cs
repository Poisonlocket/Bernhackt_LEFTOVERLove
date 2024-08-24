using AutoMapper;
using LeftOverLove.Common.Dtos;
using LeftOverLove.Common.Entities;

namespace LeftOverLove.WebAPI.Startup.MappingProfile;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        // CreateMap<TSrc, TDest>();
        CreateMap<Customer, CustomerDto>();
    }
}
