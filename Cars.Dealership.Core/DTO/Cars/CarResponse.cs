using Cars.Dealership.Core.Domain.Entities;
using Cars.Dealership.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cars.Dealership.Core.DTO.Cars
{
    public class CarResponse
    {
        public Guid Id { get; set; }

        public string? Make { get; set; }

        public string? Model { get; set; }
        public int Year { get; set; }

        public string? Color { get; set; }

        public FuelType Fuel { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public TransmissionType Transmission { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Image> Images { get; set; } = new List<Image>();


    }
}
