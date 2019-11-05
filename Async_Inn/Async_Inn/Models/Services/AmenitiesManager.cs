using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class AmenitiesManager : IAmenitiesManager
    {
        private AsyncDbContext _context;

        public AmenitiesManager(AsyncDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenities(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmenities(int id)
        {
            Amenities amenities = await GetAmenities(id);
            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task<Amenities> GetAmenities(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(amenities => amenities.ID == id);
        }

        public Task<List<Amenities>> GetAmenities()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomAmenities> GetRoomAmenitiesForRoom(int amenitiesID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAmenities(Amenities amenities)
        {
            throw new NotImplementedException();
        }
    }

}
