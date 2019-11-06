using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    /// <summary>
    /// Summary description for Amenities
    /// </summary>
    public class Amenities
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Amenity Name")]
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}

