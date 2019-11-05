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

        public async Task CreateRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            Room room = await GetRoom(id);
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Room.FirstOrDefaultAsync(room => room.ID == id);
        }

        public Task<List<Room>> GetRooms()
        {
            throw new NotImplementedException();
        }
        public Task UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HotelRoom> GetHotelRoomsForRoom(int roomID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomAmenities> GetRoomAmenitiesForRoom(int roomID)
        {
            throw new NotImplementedException();
        }
    }

}