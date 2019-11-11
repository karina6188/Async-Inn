using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.ViewModels
{
    public class RoomAmenitiesVM
    {
        public Room Room { get; set; }

        public IEnumerable<RoomAmenities> RoomAmenities { get; set; }
    }
}
