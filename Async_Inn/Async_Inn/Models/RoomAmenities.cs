using System;

namespace Async_Inn.Models
{
    /// <summary>
    /// Summary description for RoomAmenities
    /// </summary>
    public class RoomAmenities
    {
        public int AmenitiesID { get; set; }
        public int RoomID { get; set; }

        // Navigation Properties
        public Amenities Amenities { get; set; }
        public Room Room { get; set; }
    }
}
