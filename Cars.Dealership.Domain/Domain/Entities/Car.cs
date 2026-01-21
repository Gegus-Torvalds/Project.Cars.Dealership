using Cars.Dealership.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cars.Dealership.Core.Domain.Entities
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(30)]

        public string? Make { get; set; }
        [StringLength(50)]

        public string? Model { get; set; }
        public int Year { get; set; }
        [StringLength(30)]

        public string? Color { get; set; }

        public FuelType Fuel { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public TransmissionType Transmission { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Image> Images {get; set;} = new List<Image>();
        

        
    }
}
