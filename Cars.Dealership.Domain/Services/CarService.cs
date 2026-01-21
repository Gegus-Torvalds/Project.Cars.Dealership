using Cars.Dealership.Services.ServiceContracts;
using Cars.Dealership.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Cars.Dealership.Core.Domain.Entities;

namespace Cars.Dealership.Services.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _appDbContext;

        public CarService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Console.WriteLine("Car Service");
        }



        public async Task<Car> AddCarAsync(Car car)
        {
            _appDbContext.Cars.Add(car);
            await _appDbContext.SaveChangesAsync();
            return car; 
        }

        public async Task<List<Car>?> GetAllCarsAsync()
        {
            return await _appDbContext.Cars.ToListAsync();
        }

        public async Task<Car?> GetCarAsync(int id)
        {
            return await _appDbContext.Cars.SingleOrDefaultAsync(car => car.Id == id);
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var car = await _appDbContext.Cars.FindAsync(id);

            if (car is null) return false;

            _appDbContext.Remove(car);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Car?> UpdateCarAsync(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
