using Async_Inn.Models;
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

            Assert.Equal("BFour Season", hotel.Name);
        }

        [Fact]
        public void CanGetCoursePrice()
        {
            Course course = new Course()
            {
                CourseCode = "my-course-code",
                Price = 10m,
                Technology = Technology.Java
            };

            Assert.Equal(10m, course.Price);

        }


        [Fact]
        public async void SaveStudentInDb()
        {
            // Arrange

            DbContextOptions<SchoolDbContext> options = new DbContextOptionsBuilder<SchoolDbContext>()
                .UseInMemoryDatabase("SavingStudentInDb")
                .Options;

            // Act

            using (SchoolDbContext context = new SchoolDbContext(options))
            {
                Course course = new Course();
                course.CourseCode = "Amanda's Super Cool Course";
                course.Technology = Technology.DotNet;
                course.Price = 1000m;

                context.Courses.Add(course);
                await context.SaveChangesAsync();

                Course result = await context.Courses.FirstOrDefaultAsync(x => x.CourseCode == course.CourseCode);

                Assert.Equal(1000m, result.Price);

            }
        }
    }
}
