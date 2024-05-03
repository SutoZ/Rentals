namespace Rental.Domain.Models;

public class Customer
{
    public Customer() { }
    public Guid CustomerId { get; set; }
    public string Prefix { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DoB { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public string Address { get; set; }
    public Guid? RentalId { get; set; }

    public CarRental? Rental { get; set; }
}
