using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class RoomManager : IRoomManager
    {
        private AsyncDbContext _context;

        public RoomManager(AsyncDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoomAsync(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int id)
        {
            Room room = await GetRoomAsync(id);
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoomAsync(int id)
        {
            return await _context.Room.FirstOrDefaultAsync(room => room.ID == id);
        }

        public async Task<List<Room>> GetRoomsAsync()
        {
            List<Room> rooms = await _context.Room.ToListAsync();
            return rooms;
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _context.Room.Update(room);
            await _context.SaveChangesAsync();
        }

        public Task<List<RoomAmenities>> GetRoomAmenitiesForRoom(int roomID)
        {
            return null;
        }

        public IEnumerable<HotelRoom> GetHotelRoomsForRoom(int roomID, int hotelID)
        {
            return null;
        }
    }

}