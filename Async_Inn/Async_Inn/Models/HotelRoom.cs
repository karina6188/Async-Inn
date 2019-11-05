using System;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    /// <summary>
    /// Summary description for HotelRoom
    /// </summary>
    public class HotelRoom
    {
        public int HotelID { get; set; }
        [Required]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        public int RoomID { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        [Display(Name = "Pet Friendly")]
        public bool PetFriendly { get; set; }

        // Navigation Properties
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}

