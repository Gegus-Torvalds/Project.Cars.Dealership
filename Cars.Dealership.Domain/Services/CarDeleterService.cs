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



        



        public async Task<bool> DeleteCarAsync(int id)
        {
            var car = await _appDbContext.Cars.FindAsync(id);

            if (car is null) return false;

            _appDbContext.Remove(car);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

    }
}
