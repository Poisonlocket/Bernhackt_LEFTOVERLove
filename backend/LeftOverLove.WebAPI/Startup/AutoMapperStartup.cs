using AutoMapper;
using LeftOverLove.WebAPI.Startup.MappingProfile;

namespace LeftOverLove.WebAPI.Startup;

public static class AutoMapperStartup
{
    public static WebApplicationBuilder PrepareAutoMapper(this WebApplicationBuilder builder)
    {
        MapperConfiguration mapperConfig = new(mc =>
        {
            mc.AddProfile(new ItemMappingProfile());
            mc.AddProfile(new CustomerMappingProfile());
        });

        IMapper? mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);

        return builder;
    }

    public static WebApplication ApplyAutoMapper(this WebApplication app)
    {
        return app;
    }
}
