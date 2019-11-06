using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoomManager
    {        
        // Create
        Task CreateRoomAsync(Room room);

        // Read
        Task<Room> GetRoomAsync(int id);

        // Update
        Task UpdateRoomAsync(Room room);

        // Delete
        Task DeleteRoomAsync(int id);

        Task<List<Room>> GetRoomsAsync();

        IEnumerable<HotelRoom> GetHotelRoomsForRoom(int roomID);

        Task<List<RoomAmenities>> GetRoomAmenitiesForRoom(int roomID);
    }
}
