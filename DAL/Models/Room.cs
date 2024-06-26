using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Room : GenericModel
{
    /*public int Id { get; set; }*/

    public string RoomNumber { get; set; } = null!;

    public string? DetailDescription { get; set; }

    public int? MaxCapacity { get; set; }

    public int RoomTypeId { get; set; }

    public bool? Status { get; set; }

    public double? PricePerDay { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual RoomType RoomType { get; set; } = null!;
}
