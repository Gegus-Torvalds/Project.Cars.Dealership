using Cars.Dealership.Core.Domain.Entities;


namespace Cars.Dealership.Services.ServiceContracts
{
    public interface ICarService
    {
        Task<Car?> GetCarAsync(int id);
        Task<List<Car>?> GetAllCarsAsync();

    }
}
