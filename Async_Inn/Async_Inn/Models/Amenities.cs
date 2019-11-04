using System;
using System.Collections.Generic;

namespace Async_Inn.Models
{
    /// <summary>
    /// Summary description for Amenities
    /// </summary>
    public class Amenities
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Nav Props
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}

