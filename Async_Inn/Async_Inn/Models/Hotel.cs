using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Hotel
/// </summary>
public class Hotel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Phone { get; set; }

    // Nav Props
    public ICollection<HotelRoom> HotelRoom { get; set; }
}
