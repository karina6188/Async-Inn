using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class RoomService : IRoomManager
    {
        private AsyncDbContext _context;

        public RoomService(AsyncDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            await _context.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            Room room = await GetRoomById(id);
            _context.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _context.Room.FirstOrDefaultAsync(room => room.ID == id);
        }

        public async Task<List<Room>> GetRooms()
        {
            List<Room> rooms = await _context.Room.ToListAsync();
            return rooms;
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelRoom>> GetHotelOfTheRoom(int roomID)
        {
            var hotelRooms = await _context.HotelRoom.Where(x => x.RoomID == roomID).ToListAsync();
            return hotelRooms;
        }

        public IEnumerable<RoomAmenities> GetRoomAmenitiesByRoom(int roomID)
        {
            var roomAmenities = _context.RoomAmenities.Where(x => x.RoomID == roomID)
                             .Include(x => x.Amenities)
                             .Include(x => x.Room);
            return roomAmenities;
        }

        public async Task<IEnumerable<Amenities>> GetAllAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task AddAmenitiesToRoom(int roomID, int amenitiesID)
        {
            RoomAmenities newAmenities = new RoomAmenities();
            newAmenities.RoomID = roomID;
            newAmenities.AmenitiesID = amenitiesID;
            _context.RoomAmenities.Add(newAmenities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmenitiesFromRoo(int roomID, int amenityID)
        {
            RoomAmenities deletedAmenities = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomID == roomID && x.AmenitiesID == amenityID);
            _context.Remove(deletedAmenities);
            await _context.SaveChangesAsync();
        }
    }
}