using Cars.Dealership.Core.Domain.Entities;
using Cars.Dealership.Core.Domain.RepositoryContracts;
using Cars.Dealership.Core.DTO.Cars;
using Cars.Dealership.Core.ServiceContracts;
using Cars.Dealership.Core.Mappings;
namespace Cars.Dealership.Core.Services
{
    public class CarUpdaterService : ICarUpdaterService
    {
        private readonly ICarRepository _carRepository;

        public CarUpdaterService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
            Console.WriteLine("Car Service");
        }


        public async Task<bool?> UpdateCarAsync(UpdateCarRequest dto)
        {
            await _carRepository.UpdateCarAsync(CarMapper.ToEntity(dto));
            
            return true;

        }


    }
}
