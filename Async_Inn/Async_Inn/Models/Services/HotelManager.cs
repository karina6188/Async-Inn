using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class HotelManager : IHotelManager
    {
        private AsyncDbContext _context;

        public HotelManager(AsyncDbContext context)
        {
            _context = context;
        }

        public async Task CreateHotelAsync(Hotel hotel)
        {
            await _context.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotelAsync(int id)
        {
            Hotel hotel = await GetHotelAsync(id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotelAsync(int id) => await _context.Hotel.FirstOrDefaultAsync(hotel => hotel.ID == id);

        public async Task<List<Hotel>> GetHotelsAsync()
        {
            List<Hotel> hotels = await _context.Hotel.ToListAsync();
            return hotels;
        }

        public IEnumerable<HotelRoom> GetHotelRoomsForHotel(int hotelID)
        {
            return null;
        }

        public async Task UpdateHotelAsync(Hotel hotel)
        {
            _context.Hotel.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
