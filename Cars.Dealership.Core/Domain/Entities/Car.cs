using Cars.Dealership.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cars.Dealership.Core.Domain.Entities
{
    public class Car
    {
        [Key]
        public Guid Id { get; private set; }
        [StringLength(30)]

        public string? Make { get; private set; }
        [StringLength(50)]

        public string? Model { get; private set; }
        public int Year { get; private set; }
        [StringLength(30)]

        public string? Color { get; private set; }

        public FuelType Fuel { get; private set; }
        public decimal Price { get; private set; }
        public int Mileage { get; private set; }
        public TransmissionType Transmission { get; private set; }
        public bool IsAvailable { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        //explore more about why it is exactly:
        //      why we need this line of code
        //      why new List<Image>(); 
        public ICollection<Image> Images {get; private set;} = new List<Image>();



        //for behind the scenes of EntityFrameworkCore
        protected Car() { }

        //for making car object
        public Car(
         string? make,
         string? model,
         int year,
         string? color,
         FuelType fuel,
         decimal price,
         int mileage,
         TransmissionType transmission,
         bool isAvailable = true
        )
        {
            Id = Guid.NewGuid();
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            Fuel = fuel;
            Price = price;
            Mileage = mileage;
            Transmission = transmission;
            IsAvailable = isAvailable;
        }



        // for updating car object
        public Car(
         Guid id, 
         string? make,
         string? model,
         int year,
         string? color,
         FuelType fuel,
         decimal price,
         int mileage,
         TransmissionType transmission,
         bool isAvailable = true)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            Fuel = fuel;
            Price = price;
            Mileage = mileage;
            Transmission = transmission;
            IsAvailable = isAvailable;
        }

    }
}
