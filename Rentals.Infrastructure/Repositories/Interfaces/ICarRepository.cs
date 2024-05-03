using Rental.Domain.Models;

namespace Rental.Infrastructure.Repositories.Interfaces;

public interface ICarRepository
{
    Task<List<Car>> GetCarsAsync();
    Task<Car> GetCarByIdAsync(Guid id);
    Task<Guid> CreateCarAsync(Car car);
    Task DeleteCarAsync(Guid id);
    Task UpdateCarAsync(Car car);
}
