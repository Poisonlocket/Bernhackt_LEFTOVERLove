using LeftOverLove.Common.Enums;

namespace LeftOverLove.Common.Entities;

public class Item
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
    public IEnumerable<string> PicturePaths { get; set; } = new List<string>();
    public ItemState State { get; set; }
    public DateTime CreationDate { get; set; }
}