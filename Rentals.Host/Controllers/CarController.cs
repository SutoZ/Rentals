using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Rental.Host.Controllers
{
    [SwaggerTag("API definition for Car")]
    public class CarController : CustomControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [SwaggerOperation("Gets all car elements.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Get cars was successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BAD REQUEST")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Car endpoint not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]

        public async Task<IActionResult> GetCars()
        {
            var cars = await _carService.GetCarsAsync();
            return Ok(cars);
        }

        [HttpGet("GetCarById")]
        [SwaggerOperation("Gets car by Id.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Get car was successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BAD REQUEST")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Car endpoint not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        public async Task<IActionResult> GetCarById(Guid id)
        {
            var cars = await _carService.GetCarByIdAsync(id);
            return Ok(cars);
        }

        [HttpDelete]
        [SwaggerOperation("Delete car by Id.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Delete car was successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BAD REQUEST")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Car endpoint not found")]

        public async Task<IActionResult> DeleteCarById([FromQuery] Guid id)
        {
            await _carService.DeleteCarByIdAsync(id);
            return Ok();
        }

        [HttpPost]
        [SwaggerOperation("Create car")]
        [SwaggerResponse(StatusCodes.Status200OK, "Create car was successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BAD REQUEST")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Car endpoint not found")]

        public async Task<IActionResult> CreateCar([FromBody] CarCreateDto carDto)
        {
            await _carService.CreateCarAsync(carDto);
            return Ok();
        }

        [HttpPut]
        [SwaggerOperation("Update car")]
        [SwaggerResponse(StatusCodes.Status200OK, "Create car was successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BAD REQUEST")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Car endpoint not found")]

        public async Task<IActionResult> UpdateCar([FromBody] CarUpdateDto carDto)
        {
            await _carService.UpdateCarAsync(carDto);
            return Ok();
        }
    }
}