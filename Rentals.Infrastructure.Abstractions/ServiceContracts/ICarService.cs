using Rental.Core.DTO.Requests.Car;

namespace Rental.Infrastructure.Abstractions.ServiceContracts;

public interface ICarService
{
    Task<List<CarDto>> GetCarsAsync();
    Task<CarDto> GetCarByIdAsync(Guid id);
    Task<Guid> CreateCarAsync(CarCreateDto car);
    Task DeleteCarAsync(Guid id);
    Task UpdateCarAsync(CarUpdateDto car);
}
