using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class AmenitiesService : IAmenitiesManager
    {
        private AsyncDbContext _context;

        public AmenitiesService(AsyncDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenities(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAmenities(Amenities amenities)
        {
            _context.Amenities.Update(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmenities(int id)
        {
            Amenities amenities = await GetAmenitiesById(id);
            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task<Amenities> GetAmenitiesById(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(amenities => amenities.ID == id);
        }

        public async Task<List<Amenities>> GetAmenities()
        {
            List<Amenities> amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        public async Task<IEnumerable<RoomAmenities>> GetRoomForRoomAmenities(int amenitiesID)
        {
            var room = await _context.RoomAmenities.Where(x => x.AmenitiesID == amenitiesID).ToListAsync();
            return room;
        }
    }
}
