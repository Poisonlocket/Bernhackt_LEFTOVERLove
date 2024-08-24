using LeftOverLove.Common.Dtos;
using LeftOverLove.Common.Enums;

namespace LeftOverLove.Common.Entities;

public class Item
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public DateTime ExpirationDate { get; set; }
    public IList<string> PicturePaths { get; set; } = new List<string>();
    public ItemState State { get; set; }
    public DateTime CreationDate { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
}
