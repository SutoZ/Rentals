using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Rental.Core.Services;

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

    public async Task DeleteCarByIdAsync(Guid id)
    {
        _logger.LogInformation($"{nameof(DeleteCarByIdAsync)} method called");

        var carToDelete = await _carRepository.GetCarByIdAsync(id);

        if (carToDelete is not null)
            await _carRepository.DeleteCarAsync(carToDelete.CarId);

        _logger.LogInformation($"{nameof(DeleteCarByIdAsync)} method finished");

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
        var carDtos = cars.Select(_mapper.Map<CarDto>).ToList();

        _logger.LogInformation("{methodname} method executed", nameof(GetCarsAsync));

        return carDtos;
    }

    public async Task UpdateCarAsync(CarUpdateDto carUpdateDto)
    {
        _logger.LogInformation($"{nameof(UpdateCarAsync)} method called");

        var carToUpdate = _mapper.Map<Car>(carUpdateDto);

        await _carRepository.UpdateCarAsync(carToUpdate);

        _logger.LogInformation($"{nameof(UpdateCarAsync)} method finished");
    }
}
