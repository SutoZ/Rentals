namespace Rental.Core.Services.Interfaces;
public interface ICarService
{
    Task<List<CarDto>> GetCarsAsync();
    Task<CarDto> GetCarByIdAsync(Guid id);
    Task<Guid> CreateCarAsync(CarCreateDto car);
    Task DeleteCarByIdAsync(Guid id);
    Task UpdateCarAsync(CarUpdateDto car);
}
