using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IAmenitiesManager
    {        
        // Create
        Task CreateAmenitiesAsync(Amenities amenities);

        // Read
        Task<Amenities> GetAmenitiesAsync(int id);

        // Update
        Task UpdateAmenitiesAsync(Amenities amenities);

        // Delete
        Task DeleteAmenitiesAsync(int id);

        Task<List<Amenities>> GetAmenitiesAsync();

        IEnumerable<RoomAmenities> GetRoomAmenitiesForRoom(int amenitiesID);
    }
}
