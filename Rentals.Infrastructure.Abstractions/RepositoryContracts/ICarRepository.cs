using Rental.Domain.Models;

namespace Rental.Infrastructure.Abstractions.RepositoryContracts;

public interface ICarRepository
{
    Task<List<Car>> GetCarsAsync();
    Task<Car> GetCarByIdAsync(Guid id);
    Task<Guid> CreateCarAsync(Car car);
    Task DeleteCarAsync(Guid id);
    Task UpdateCarAsync(Car car);
}
