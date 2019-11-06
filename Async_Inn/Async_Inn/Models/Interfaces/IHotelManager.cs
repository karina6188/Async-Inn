using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotelManager
    {
        // Create
        Task CreateHotelAsync(Hotel hotel);

        // Read
        Task<Hotel> GetHotelAsync(int id);

        // Update
        Task UpdateHotelAsync(Hotel hotel);

        // Delete
        Task DeleteHotelAsync(int id);

        Task<List<Hotel>> GetHotelsAsync();

        IEnumerable<HotelRoom> GetHotelRoomsForHotel(int hotelID);
    }
}
