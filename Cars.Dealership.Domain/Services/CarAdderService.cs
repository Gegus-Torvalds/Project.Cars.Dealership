using Cars.Dealership.Core.
using Cars.Dealership.Core.Domain.Entities;

namespace Cars.Dealership.Services.Services
{
    public class CarService : ICarAdderService
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

    }
}
