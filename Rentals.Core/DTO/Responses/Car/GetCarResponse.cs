using Rental.Domain.Enums;

namespace Rental.Core.DTO.Responses.Car;

public class GetCarResponse
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Details { get; set; }
    public Status Status { get; set; }
    public Guid? RentalId { get; set; }
    public GetCarRentalResponse RentalResponse { get; set; }
}
