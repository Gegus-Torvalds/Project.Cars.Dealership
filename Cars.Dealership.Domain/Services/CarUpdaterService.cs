using Cars.Dealership.Services.ServiceContracts;
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



        

        

        public async Task<Car?> UpdateCarAsync(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
