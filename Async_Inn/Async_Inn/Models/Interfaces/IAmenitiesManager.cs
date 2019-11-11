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
        Task<Amenities> GetAmenitiesById(int id);
        Task<List<Amenities>> GetAmenities();

        // Update
        Task UpdateAmenities(Amenities amenities);

        // Delete
        Task DeleteAmenities(int id);

        Task<IEnumerable<RoomAmenities>> GetRoomForRoomAmenities(int amenitiesID);
    }
}
