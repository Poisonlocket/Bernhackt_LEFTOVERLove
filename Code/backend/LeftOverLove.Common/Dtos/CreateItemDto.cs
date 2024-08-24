public class CreateItemDto
{
    public string Description { get; set; } = null!;
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int CustomerId { get; set; }
}
