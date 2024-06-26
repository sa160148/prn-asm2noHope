using System;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Models;

public partial class Booking : GenericModel
{
    /*public int Id { get; set; }*/

    public DateTime? BookingDate { get; set; }

    public double? TotalPrice { get; set; }

    public int CustomerId { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual Customer Customer { get; set; } = null!;
}
