using AutoMapper;
using Microsoft.Extensions.Logging;
using Rental.Application.Core.ServiceContracts.Interfaces;
using Rental.Core.DTO.Requests.Car;
using Rental.Domain.Models;
using Rental.Infrastructure.Repositories.Interfaces;

namespace Rental.Application.Core.ServiceContracts;

public class CarService : ICarService
{
    private readonly ILogger<ICarRepository> _logger;
    private readonly IMapper _mapper;
    private readonly ICarRepository _carRepository;

    public CarService(ILogger<ICarRepository> logger, IMapper mapper, ICarRepository carRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _carRepository = carRepository;
    }

    public async Task<Guid> CreateCarAsync(CarCreateDto createDto)
    {
        _logger.LogInformation($"{nameof(CreateCarAsync)} method called");

        var carToCreate = _mapper.Map<Car>(createDto);
        var createdCar = await _carRepository.CreateCarAsync(carToCreate);

        _logger.LogInformation($"{nameof(CreateCarAsync)} method finished");

        return createdCar;
    }

    public async Task DeleteCarAsync(Guid id)
    {
        _logger.LogInformation($"{nameof(DeleteCarAsync)} method called");

        var carToDelete = await _carRepository.GetCarByIdAsync(id);

        if (carToDelete != null)
            await _carRepository.DeleteCarAsync(carToDelete.CarId);

        _logger.LogInformation($"{nameof(DeleteCarAsync)} method finished");

    }

    public async Task<CarDto> GetCarByIdAsync(Guid id)
    {
        _logger.LogInformation($"{nameof(GetCarByIdAsync)} method called");

        var car = await _carRepository.GetCarByIdAsync(id);
        var carDto = _mapper.Map<CarDto>(car);

        _logger.LogInformation($"{nameof(GetCarByIdAsync)} method finished");

        return carDto;
    }

    public async Task<List<CarDto>> GetCarsAsync()
    {
        _logger.LogInformation("{methodname} method called", nameof(GetCarsAsync));

        var cars = await _carRepository.GetCarsAsync();
        var cardtos = cars.Select(x => _mapper.Map<CarDto>(x)).ToList();

        _logger.LogInformation("{methodname} method executed", nameof(GetCarsAsync));

        return cardtos;
    }

    public async Task UpdateCarAsync(CarUpdateDto carUpdateDto)
    {
        _logger.LogInformation($"{nameof(UpdateCarAsync)} method called");

        var carToUpdate = _mapper.Map<Car>(carUpdateDto);

        await _carRepository.UpdateCarAsync(carToUpdate);

        _logger.LogInformation($"{nameof(UpdateCarAsync)} method finished");
    }
}
