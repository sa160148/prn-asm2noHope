using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class BookingDetail : GenericModel
{
    /*public int Id { get; set; }*/

    public int BookingId { get; set; }

    public int RoomId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public double? ActualPrice { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
