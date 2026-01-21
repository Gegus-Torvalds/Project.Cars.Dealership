using Cars.Dealership.Core.Domain.Entities;
using Cars.Dealership.Core.Domain.RepositoryContracts;
using Cars.Dealership.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Dealership.Infrastructure.Repositories
{
    internal class CarRepository : ICarRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Car> CreateCarAsync(Car car)
        {
            _applicationDbContext.Cars.Add(car);
            await _applicationDbContext.SaveChangesAsync();
            return car;
        }

        public async Task<bool> DeleteCarAsync(Guid id)
        {
            _applicationDbContext.Cars.Remove(_applicationDbContext.Cars.First(car => car.Id == id));
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _applicationDbContext.Cars.Include(car => car.Images).ToListAsync();
            
        }

        public async Task<Car> GetCarAsync(Guid id)
        {
            return await _applicationDbContext.Cars.FirstAsync(car => car.Id == id);
        }

        public  async Task<Car> UpdateCarAsync(Car car)
        {
            _applicationDbContext.Update(car);
            await _applicationDbContext.SaveChangesAsync(); 
            return car;
        }

        public async Task<List<Car>> GetAvailableCarsAsync()
        {
           return await _applicationDbContext.Cars.Where(car => car.IsAvailable == true).ToListAsync();
        }

    }
}
