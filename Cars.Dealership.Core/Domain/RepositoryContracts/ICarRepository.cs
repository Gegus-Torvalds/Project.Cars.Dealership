using Cars.Dealership.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Dealership.Core.Domain.RepositoryContracts
{
    public interface ICarRepository
    {
        Task<Car> GetCarAsync(Guid id);
        Task<List<Car>> GetAllCarsAsync();
        Task<List<Car>> GetAvailableCarsAsync();

        Task<Car> CreateCarAsync(Car car);
        Task<Car> UpdateCarAsync(Car car);
        Task<bool> DeleteCarAsync(Guid id);

   }
}
