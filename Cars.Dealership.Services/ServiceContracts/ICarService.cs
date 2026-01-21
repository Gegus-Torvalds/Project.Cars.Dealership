using Cars.Dealership.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Dealership.Services.ServiceContracts
{
    public interface ICarService
    {
        Task<Car?> GetCarAsync(int id);
        Task<List<Car>?> GetAllCarsAsync();
        Task<Car> AddCarAsync(Car car);
        Task<Car?> UpdateCarAsync(Car car);
        Task<bool> RemoveCarAsync(int id);

    }
}
