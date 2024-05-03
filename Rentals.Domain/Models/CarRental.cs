namespace Rental.Domain.Models;

public class CarRental
{
    public CarRental()
    {
        Customers = new HashSet<Customer>();
        Cars = new HashSet<Car>();
    }

    public Guid CarRentalId { get; set; }

    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public decimal Price { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? CarId { get; set; }

    public ICollection<Customer> Customers { get; set; }
    public ICollection<Car> Cars { get; set; }
}
