using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.ViewModels
{
    public class RoomHotelVM
    {
        public IEnumerable<HotelRoom> HotelRoom { get; set; }
        public Hotel Hotel { get; set; }
    }
}
