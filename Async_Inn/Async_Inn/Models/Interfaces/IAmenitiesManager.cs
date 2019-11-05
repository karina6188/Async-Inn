using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IAmenitiesManager
    {        
        // Create
        Task CreateAmenities(Amenities amenities);

        // Read
        Task GetAmenities(int id);

        // Update
        Task UpdateAmenities(Amenities amenities);

        // Delete
        Task DeleteAmenities(int id);

        Task<List<Amenities>> GetAmenities();

        IEnumerable<RoomAmenities> GetRoomAmenitiesForRoom(int amenitiesID);
    }
}
