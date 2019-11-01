using Microsoft.EntityFrameworkCore;
using System;

/// <summary>
/// Summary description for AsyncDbContext
/// </summary>
public class AsyncDbContext : DbContext
{
	public AsyncDbContext(DbContextOptions<AsyncDbContext>options): base(options)
	{
        
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HotelRoom>().HasKey(enrollment =>
        new { enrollment.HotelID, enrollment.RoomNumber });

        modelBuilder.Entity<RoomAmenities>().HasKey(enrollment =>
        new { enrollment.AmenitiesID, enrollment.RoomID });
    }

    public DbSet<Hotel> Hotel { get; set; }
    public DbSet<HotelRoom> HotelRoom { get; set; }
    public DbSet<Room> Room { get; set; }
    public DbSet<RoomAmenities> RoomAmenities { get; set; }
    public DbSet<Amenities> Amenities { get; set; }
}
