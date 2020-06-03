using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DempApp.Data.Models
{
    public class Phone
    {
        [Key]
        public Guid PhoneId { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string ImageFile { get; set; }
    }
}
