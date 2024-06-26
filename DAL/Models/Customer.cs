using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Customer : GenericModel
{
    /*public int Id { get; set; }*/

    public string? FullName { get; set; }

    public string? Telephone { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? Birthday { get; set; }

    public bool? Status { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
