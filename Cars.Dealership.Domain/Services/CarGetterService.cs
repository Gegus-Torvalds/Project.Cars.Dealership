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



        

        public async Task<List<Car>?> GetAllCarsAsync()
        {
            return await _appDbContext.Cars.ToListAsync();
        }

        public async Task<Car?> GetCarAsync(int id)
        {
            return await _appDbContext.Cars.SingleOrDefaultAsync(car => car.Id == id);
        }

        
    }
}
