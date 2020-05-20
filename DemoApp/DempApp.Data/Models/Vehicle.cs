using System;
using System.ComponentModel.DataAnnotations;

namespace DempApp.Data.Models
{
    public class Vehicle
    {
        [Key]
        public Guid VehicleId { get; set; }
        [Required]
        public string Make { get; set; }
        public string  Model { get; set; }
        public decimal Price { get; set; }
    }
}
