using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    /// <summary>
    /// Summary description for Hotel
    /// </summary>
    public class Hotel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Hotel Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Phone { get; set; }

        // Navigation Properties
        public ICollection<HotelRoom> HotelRoom { get; set; }
    }
}
