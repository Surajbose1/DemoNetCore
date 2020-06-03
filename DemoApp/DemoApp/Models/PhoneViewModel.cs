using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models
{
    public class PhoneViewModel  
    {
        [Required]
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public IFormFile ImageFile { get; set; }
        [Required]
        public Guid PhoneId { get; set; }
        public string ImagePath { get; set; }
    }
}