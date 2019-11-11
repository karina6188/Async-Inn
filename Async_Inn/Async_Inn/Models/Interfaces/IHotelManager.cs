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
        Task<Hotel> GetHotelById(int id);
        Task<List<Hotel>> GetHotels();

        // Update
        Task UpdateHotel(Hotel hotel);

        // Delete
        Task DeleteHotel(int id);

        IEnumerable<HotelRoom> GetHotelRooms(int hotelID);
        Task AddRoomsToHotel(HotelRoom hotelRoom);
        Task DeleteRoomsFromHotel(int hotelID, int roomID);
    }
}
