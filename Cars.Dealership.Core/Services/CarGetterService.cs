
using Cars.Dealership.Core.Domain.Entities;
using Cars.Dealership.Core.Domain.RepositoryContracts;
using Cars.Dealership.Core.DTO.Cars;
using Cars.Dealership.Core.Mappings;
using Cars.Dealership.Core.ServiceContracts;

namespace Cars.Dealership.Core.Services
{
    public class CarGetterService : ICarGetterService
    {
        private readonly ICarRepository _carRepository;

        public CarGetterService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
            Console.WriteLine("Car Service");
        }



        public async Task<CarResponse?> GetCarAsync(Guid id)
        {
            return CarMapper.ToResponse(await _carRepository.GetCarAsync(id));
        }

        public async Task<List<CarResponse>?> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllCarsAsync();

            if (cars is null)
                return null;
                

            //  explore this extensively
            return cars.Select(CarMapper.ToResponse).ToList();
        }
    }
}
