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

        public async Task CreateHotel(Hotel hotel)
        {
            await _context.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id) => await _context.Hotel.FirstOrDefaultAsync(hotel => hotel.ID == id);

        public Task<List<Hotel>> GetHotels()
        {
            var hotels = _context.Hotel.ToListAsync();
            return hotels;
        }

        public IEnumerable<HotelRoom> GetHotelRoomsForHotel(int hotelID)
        {
            return null;
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotel.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
