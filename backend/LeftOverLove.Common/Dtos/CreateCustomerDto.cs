namespace LeftOverLove.Common.Dtos;
public class CreateCustomerDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public int Points { get; set; } = -1!;
}
