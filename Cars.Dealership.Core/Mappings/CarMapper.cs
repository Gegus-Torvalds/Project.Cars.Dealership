using System;
using System.Collections.Generic;
using System.Text;
using Cars.Dealership.Core.Domain.Entities;
using Cars.Dealership.Core.DTO.Cars;

namespace Cars.Dealership.Core.Mappings
{
    public static class CarMapper
    {
        public static Car ToEntity(CreateCarRequest request)
        {
            return new Car
            (
            request.Make,
            request.Model,
            request.Year,
            request.Color,
            request.Fuel,
            request.Price,
            request.Mileage,
            request.Transmission,
            request.IsAvailable
            );
        }


        public static CarResponse ToResponse(Car entity)
        {
            return new CarResponse()
            {
                Id = entity.Id,
                Make = entity.Make,
                Model = entity.Model,
                Year = entity.Year,
                Color = entity.Color,
                Fuel = entity.Fuel,
                Price = entity.Price,
                Mileage = entity.Mileage,
                Transmission = entity.Transmission, 
                IsAvailable = entity.IsAvailable,
                CreatedAt = entity.CreatedAt,
                Images = entity.Images,
                
            };
        }

        public static Car ToEntity(UpdateCarRequest request)
        {
            return new Car(
                request.Id,
                request.Make,
                request.Model,
                request.Year,
                request.Color,
                request.Fuel,
                request.Price,
                request.Mileage,
                request.Transmission,
                request.IsAvailable
                );
        }

    }
}
