namespace LeftOverLove.Common.Dtos;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public double Longitude { get; set; } 
    public double Latitude { get; set; }
    public int Points { get; set; }
}
