using System;

namespace Async_Inn.Models
{
    /// <summary>
    /// Summary description for HotelRoom
    /// </summary>
    public class HotelRoom
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public int RoomID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }

        // Nav Props
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}

