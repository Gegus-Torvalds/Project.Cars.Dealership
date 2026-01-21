

using Cars.Dealership.Core.Domain.Entities;
using Cars.Dealership.Core.DTO.Cars;

namespace Cars.Dealership.Core.ServiceContracts
{
    public interface ICarUpdaterService
    {
        Task<bool?> UpdateCarAsync(UpdateCarRequest dto);

    }
}
