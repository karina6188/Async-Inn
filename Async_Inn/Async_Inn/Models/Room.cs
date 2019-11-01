using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Room
/// </summary>
public class Room
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Layout { get; set; }

    // Nav Props
    public ICollection<HotelRoom> HotelRoom { get; set; }
    public ICollection<RoomAmenities> RoomAmenities { get; set; }

    public enum RoomLayout
    {
        Studio = 0,
        OneBedroom,
        TwoBedroom
    }
}
