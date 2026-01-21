

namespace Cars.Dealership.Core.Domain.Entities
{
    public class Image
    {

        public Guid Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsCover { get; set; } 


        //FK
        public Guid CarId { get; set; } 
        public Car Car { get; set; }
    }
}
