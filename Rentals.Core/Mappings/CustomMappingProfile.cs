using AutoMapper;
using Rental.Core.DTO.Requests.Car;
using Rental.Core.DTO.Requests.CarRental;

namespace Rental.Core.Mappings;

public class CustomMappingProfile : Profile
{
    public CustomMappingProfile()
    {
        #region Car

        CreateMap<Car, CarDto>();
        CreateMap<Car, CarCreateDto>();
        CreateMap<Car, CarUpdateDto>();
        CreateMap<Car, CarFilterDto>();
        CreateMap<CarDto, CarUpdateDto>();

        #endregion

        #region CarRental

        CreateMap<CarRental, CarRentalDto>();
        CreateMap<CarRental, CarRentalCreateDto>();
        CreateMap<CarRental, CarRentalFilterDto>();

        #endregion
    }
}
