using AutoMapper;
using LeftOverLove.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace LeftOverLove.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HaversineDistanceController : ControllerBase
{
    private readonly IMapper _mapper;

    public HaversineDistanceController(
        IMapper mapper
    )
    {
        _mapper = mapper;
    }

    [HttpGet("GetHaversineDistance/{latitude1}/{longitude1}/{latitude2}/{longitude2}")]
    public ActionResult<int> GetHaversineDistance(
        string latitude1,
        string longitude1,
        string latitude2,
        string longitude2)
    {
        if (!double.TryParse(latitude1, out var doubleLatatude1)) return BadRequest("Coordinates (latatude1) not correctly formatted");
        if (!double.TryParse(longitude1, out var doubleLongatude1)) return BadRequest("Coordinates (longatude1) not correctly formatted");
        if (!double.TryParse(latitude2, out var doubleLatatude2)) return BadRequest("Coordinates (latatude2) not correctly formatted");
        if (!double.TryParse(longitude2, out var doubleLongatude2)) return BadRequest("Coordinates (longatude2) not correctly formatted");
        var diffInMeters = Common.GeolocationUtils.HaversineDistance(doubleLatatude1, doubleLongatude1, doubleLatatude2, doubleLongatude2);
        return Ok(_mapper.Map<int>(diffInMeters));
    }
}
