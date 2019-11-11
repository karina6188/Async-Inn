using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class HotelService : IHotelManager
    {
        private AsyncDbContext _context;

        public HotelService(AsyncDbContext context)
        {
            _context = context;
        }

        public async Task CreateHotel(Hotel hotel)
        {
            await _context.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotel.Update(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotelById(id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotelById(int id) => await _context.Hotel.FirstOrDefaultAsync(hotel => hotel.ID == id);

        public async Task<List<Hotel>> GetHotels()
        {
            List<Hotel> hotels = await _context.Hotel.ToListAsync();
            return hotels;
        }

        public IEnumerable<HotelRoom> GetHotelRooms(int hotelID)
        {
            var hotelRooms = _context.HotelRoom.Where(x => x.HotelID == hotelID)
                             .Include(e => e.Hotel)
                             .Include(e => e.Room);
            return hotelRooms;
        }

        public async Task AddRoomsToHotel(HotelRoom hotelRoom)
        {
            await _context.HotelRoom.AddAsync(hotelRoom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomsFromHotel(int hotelID, int roomID)
        {
            HotelRoom hotelRoom = await _context.HotelRoom.FirstOrDefaultAsync(x => x.HotelID == hotelID && x.RoomID == roomID);
            _context.Remove(hotelRoom);
            await _context.SaveChangesAsync();
        }
    }
}
