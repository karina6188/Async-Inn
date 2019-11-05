using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    /// <summary>
    /// Summary description for Room
    /// </summary>
    public class Room
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public RoomLayout Layout { get; set; }

        // Nav Props
        public ICollection<HotelRoom> HotelRoom { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }

        public enum RoomLayout
        {
            Studio = 0,
            OneBedroom,
            TwoBedroom
        }
    }
}

