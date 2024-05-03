using Rental.Core.DTO.Requests.CarRental;
using Rental.Domain.Enums;

namespace Rental.Core.DTO.Requests.Car;

public class CarFilterDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Details { get; set; }
    public Status Status { get; set; }
    public Guid? RentalId { get; set; }
    public CarRentalFilterDto Rental { get; set; }
}
