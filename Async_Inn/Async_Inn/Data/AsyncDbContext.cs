using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using static Async_Inn.Models.Room;

namespace Async_Inn.Data
{
    /// <summary>
    /// Summary description for AsyncDbContext
    /// </summary>
    public class AsyncDbContext : DbContext
    {
        public AsyncDbContext(DbContextOptions<AsyncDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(hotelRoom =>
            new { hotelRoom.HotelID, hotelRoom.RoomNumber });

            modelBuilder.Entity<RoomAmenities>().HasKey(roomAmenities =>
            new { roomAmenities.AmenitiesID, roomAmenities.RoomID });

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Curio del Coronado",
                    StreetAddress = "1500 Orange Ave",
                    City = "Coronado",
                    State = "CA",
                    Phone = "(619)435-6611"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Shutters on the Beach",
                    StreetAddress = "1 Pico Blvd",
                    City = "Santa Monica",
                    State = "CA",
                    Phone = "(310)458-0030"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Four Seasons",
                    StreetAddress = "57 E 57th St",
                    City = "New York",
                    State = "NY",
                    Phone = "(212)758-5700"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "The Langham",
                    StreetAddress = "330 N Wabash Ave",
                    City = "Chicago",
                    State = "IL",
                    Phone = "(312)923-9988"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Fairmont Heritage",
                    StreetAddress = "900 North Point St",
                    City = "San Francisco",
                    State = "CA",
                    Phone = "(415)268-9900"
                }
                );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Coronado Sea Breeze",
                    Layout = RoomLayout.Studio
                },
                new Room
                {
                    ID = 2,
                    Name = "Nightly New York",
                    Layout = RoomLayout.OneBedroom
                },
                new Room
                {
                    ID = 3,
                    Name = "Luxury Indulgence",
                    Layout = RoomLayout.TwoBedroom
                },
                new Room
                {
                    ID = 4,
                    Name = "Misty Bay View",
                    Layout = RoomLayout.Studio
                },
                new Room
                {
                    ID = 5,
                    Name = "Pacific Beach House",
                    Layout = RoomLayout.OneBedroom
                },
                new Room
                {
                    ID = 6,
                    Name = "Chicago Cityscape",
                    Layout = RoomLayout.TwoBedroom
                }
                );
        }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}
