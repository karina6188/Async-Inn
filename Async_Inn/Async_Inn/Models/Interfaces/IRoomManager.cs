using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoomManager
    {        
        // Create
        Task CreateRoom(Room room);

        // Read
        Task<Room> GetRoom(int id);

        // Update
        Task UpdateRoom(Room room);

        // Delete
        Task DeleteRoom(int id);

        Task<List<Room>> GetRooms();

        IEnumerable<HotelRoom> GetHotelRoomsForRoom(int roomID);
        IEnumerable<RoomAmenities> GetRoomAmenitiesForRoom(int roomID);
    }
}
