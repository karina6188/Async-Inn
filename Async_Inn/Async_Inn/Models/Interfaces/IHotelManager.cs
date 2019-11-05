using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotelManager
    {
        // Create
        Task CreateHotel(Hotel hotel);

        // Read
        Task GetHotel(int id);

        // Update
        Task UpdateHotel(Hotel hotel);

        // Delete
        Task DeleteHotel(int id);

        Task<List<Hotel>> GetHotels();

        IEnumerable<HotelRoom> GetHotelRoomsForHotel(int hotelID);
    }
}
