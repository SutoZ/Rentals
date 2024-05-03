using Rental.Domain.Enums;

namespace Rental.Domain.Models;

public class Car
{
    public Guid CarId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Details { get; set; }
    public Status Status { get; set; }
    public Guid? RentalId { get; set; }
    public CarRental Rental { get; set; }
}
