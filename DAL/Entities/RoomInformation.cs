﻿using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class RoomInformation
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string? RoomDetailDescription { get; set; }

    public int? RoomMaxCapacity { get; set; }

    public int RoomTypeId { get; set; }

    public bool? RoomStatus { get; set; }

    public double? RoomPricePerDay { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual RoomType RoomType { get; set; } = null!;
}
