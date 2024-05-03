using Microsoft.EntityFrameworkCore;

namespace Rental.Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    private readonly RentalContext _context;

    public CarRepository(RentalContext context) => _context = context;

    public async Task<Guid> CreateCarAsync(Car car)
    {
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();

        return car.CarId;
    }

    public async Task DeleteCarAsync(Guid id)
    {
        var car = await _context.Cars.FirstOrDefaultAsync(c => c.CarId == id);
        _context.Cars.Remove(car);

        await _context.SaveChangesAsync();
    }

    public async Task<Car> GetCarByIdAsync(Guid id)
    {
        var car = await _context.Cars
            .FirstOrDefaultAsync(x => x.CarId == id);

        return car;
    }

    public async Task<List<Car>> GetCarsAsync()
    {
        var cars = await _context.Cars.AsNoTracking().ToListAsync();
        return cars;
    }

    public async Task UpdateCarAsync(Car car)
    {
        _context.Cars.Update(car);
        await _context.SaveChangesAsync();
    }
}