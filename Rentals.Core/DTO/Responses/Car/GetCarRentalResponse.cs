namespace Rental.Core.DTO.Responses.Car;

public class GetCarRentalResponse
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public decimal Price { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? CarId { get; set; }
}
