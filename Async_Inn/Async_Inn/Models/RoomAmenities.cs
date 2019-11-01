using System;

/// <summary>
/// Summary description for RoomAmenities
/// </summary>
public class RoomAmenities
{
    public int AmenitiesID { get; set; }
    public int RoomID { get; set; }

    // Nav Props
    public Amenities Amenities { get; set; }
    public Room Room { get; set; }
}
