using Rental.Core.DTO.Requests.Car;

namespace Rental.Application.Core.ServiceContracts.Interfaces;
public interface ICarService
{
    Task<List<CarDto>> GetCarsAsync();
    Task<CarDto> GetCarByIdAsync(Guid id);
    Task<Guid> CreateCarAsync(CarCreateDto car);
    Task DeleteCarAsync(Guid id);
    Task UpdateCarAsync(CarUpdateDto car);
}
