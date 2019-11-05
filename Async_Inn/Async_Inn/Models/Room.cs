using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    /// <summary>
    /// Summary description for Room
    /// </summary>
    public class Room
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Room Name")]
        public string Name { get; set; }
        [Required]
        public Layout Layout { get; set; }

        // Navigation Properties
        public ICollection<HotelRoom> HotelRoom { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }

    }
    public enum Layout
    {
        Studio = 0,
        [Display(Name = "One Bedroom")]
        OneBedroom,
        [Display(Name = "Two Bedroom")]
        TwoBedroom
    }
}

