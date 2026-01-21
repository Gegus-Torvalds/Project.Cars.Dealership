using Cars.Dealership.Core.Domain.Entities;


namespace Cars.Dealership.Services.ServiceContracts
{
    public interface ICarService
    {
        Task<Car?> UpdateCarAsync(Car car);

    }
}
