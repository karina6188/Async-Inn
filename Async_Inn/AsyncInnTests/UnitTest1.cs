using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace AsyncInnTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanGetHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Hyatt Regency";
            hotel.City = "Seattle";
            hotel.StreetAddress = "808 Howell St";
            hotel.State = "WA";

            Assert.Equal("Hyatt Regency", hotel.Name);
            Assert.Equal("Seattle", hotel.City);
            Assert.Equal("808 Howell St", hotel.StreetAddress);
            Assert.Equal("WA", hotel.State);
        }

        [Fact]
        public void CanChangeHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Four Season";

            Assert.Equal("Four Season", hotel.Name);
        }

        [Fact]
        public void CanGetRoomInfo()
        {
            Room room = new Room()
            {
                Name = "Sunset at Puget Sound",
                Layout = Layout.OneBedroom,
            };
            Assert.Equal("Sunset at Puget Sound", room.Name);
        }

        [Fact]
        public void CanGetAmenityInfo()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Hair Dryer";

            Assert.Equal("Hair Dryer", amenity.Name);
        }

        [Fact]
        public void CanChangeAmenityInfo()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Safe";

            Assert.Equal("Safe", amenity.Name);
        }

        [Fact]
        public async void SaveRoomInDb()
        {
            // Arrange

            DbContextOptions<AsyncDbContext> options = new DbContextOptionsBuilder<AsyncDbContext>()
                .UseInMemoryDatabase("SaveRoomInDb")
                .Options;

            // Act

            using (AsyncDbContext context = new AsyncDbContext(options))
            {
                Room room = new Room();
                room.Name = "Cloud Inn";
                room.Layout = Layout.Studio;

                context.Room.Add(room);
                await context.SaveChangesAsync();

                Room result = await context.Room.FirstOrDefaultAsync(x => x.Name == room.Name);

                Assert.Equal("Cloud Inn", result.Name);
            }
        }
    }
}
