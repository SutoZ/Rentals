namespace Rental.Domain.Models;

public class Owner
{
    public Owner() { }
    public Guid OwnerId { get; set; }
    public string Prefix { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool IsActive { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public string Address { get; set; }
}
