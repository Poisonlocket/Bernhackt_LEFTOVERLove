using LeftOverLove.Common.Enums;

namespace LeftOverLove.Common.Dtos;

public class ItemDto
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public DateTime ExpirationDate { get; set; }
    public IEnumerable<string> PicturePaths { get; set; } = new List<string>();
    public ItemState State { get; set; }
    public DateTime CreationDate { get; set; }
    public int CustomerId { get; set; }
}
