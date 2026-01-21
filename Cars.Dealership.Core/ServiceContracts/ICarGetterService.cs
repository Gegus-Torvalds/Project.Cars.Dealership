
using Cars.Dealership.Core.DTO.Cars;

namespace Cars.Dealership.Core.ServiceContracts
{
    public interface ICarGetterService
    {
        Task<CarResponse?> GetCarAsync(Guid dto);
        Task<List<CarResponse>?> GetAllCarsAsync();

    }
}
