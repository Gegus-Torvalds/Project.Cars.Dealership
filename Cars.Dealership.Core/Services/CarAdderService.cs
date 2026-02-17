using Cars.Dealership.Core.ServiceContracts;
using Cars.Dealership.Core.Domain.Entities;
using Cars.Dealership.Core.DTO.Cars;
using Cars.Dealership.Core.Domain.RepositoryContracts;
using Cars.Dealership.Core.Mappings;

namespace Cars.Dealership.Core.Services
{
    public class CarAdderService : ICarAdderService
    {
        private readonly ICarRepository _carRepository; 

        public CarAdderService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            /////////////////////////////////////
            /////////////////////////////////////
            /////////////////////////////////////
            /////////////////////////////////////
            //                                 //
            //          stopped here           //
            //     have to add all services    //
            //                                 //
            /////////////////////////////////////
            /////////////////////////////////////
            /////////////////////////////////////
            /////////////////////////////////////
            /////////////////////////////////////


            await _carRepository.CreateCarAsync(car);
            return car;
        }
    }
}
