public class CreateItemDto
{
    public string Description { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
    public int CustomerId { get; set; }
}
