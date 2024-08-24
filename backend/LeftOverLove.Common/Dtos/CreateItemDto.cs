using LeftOverLove.Common.Enums;

namespace LeftOverLove.Common.Dtos;

public class CreateItemDto
{
    public string Description { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
    public ItemState State { get; set; }
    public DateTime CreationDate { get; set; }
    public int CustomerId { get; set; } = -1;
    public Customer? Customer { get; set; } = null;
}
