using Cars.Dealership.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cars.Dealership.Core.DTO.Cars
{
    public class CreateCarRequest
    {

        [Required]
        public string? Make { get; set; }
        [Required]
        public string? Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]

        public string? Color { get; set; }
        [Required]

        public FuelType Fuel { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public TransmissionType Transmission { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]

        public ICollection<string> ImagesUrl { get; set; } = new List<string>();

    }
}
