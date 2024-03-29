﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoomManager
    {        
        // Create
        Task CreateRoom(Room room);

        // Read
        Task<Room> GetRoomById(int id);
        Task<List<Room>> GetRooms();

        // Update
        Task UpdateRoom(Room room);

        // Delete
        Task DeleteRoom(int id);

        IEnumerable<RoomAmenities> GetRoomAmenitiesByRoom(int roomID);
        Task<IEnumerable<Amenities>> GetAllAmenities();
        Task<IEnumerable<HotelRoom>> GetHotelOfTheRoom(int roomID);
        Task AddAmenitiesToRoom(int roomID, int amenitiesID);
        Task DeleteAmenitiesFromRoo(int roomID, int amenityID);
    }
}
