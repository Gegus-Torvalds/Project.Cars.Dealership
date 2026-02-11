using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Dealership.Core.Domain.Entities
{
    public class RepairService
    {

        public Guid Id { get; set; }
        public string? Make {  get; set; }
        public string? Model { get; set; }
        public string? Info { get; set; }

        public DateTime ReservationDate { get; set; }

        public Guid CustomerUserId {  get; set; }
    }
}
