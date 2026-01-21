
using Cars.Dealership.Core.ServiceContracts;
using Cars.Dealership.Core.Domain.RepositoryContracts; 

namespace Cars.Dealership.Core.Services
{
    public class CarDeleterService : ICarDeleterService
    {
        private readonly ICarRepository _carRepository;

        public CarDeleterService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
            Console.WriteLine("Car Service");
        }



        public async Task<bool> DeleteCarAsync(Guid id)
        {
            var car = _carRepository.DeleteCarAsync(id); 
            if (car is null) return false;

            

            return true;
        }

        
    }
}
