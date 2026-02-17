
using Cars.Dealership.Core.Domain.Entities;
using Cars.Dealership.Core.DTO.Cars;

namespace Cars.Dealership.Core.ServiceContracts
{
    public interface ICarAdderService
    {
        Task<Car> AddCarAsync(Car car);

    }
}
