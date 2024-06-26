using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Entities;

public partial class Customer : BaseModel
{
    public int CustomerId { get; set; }

    public string? CustomerFullName { get; set; }

    public string? Telephone { get; set; }

    public string EmailAddress { get; set; } = null!;

    public DateOnly? CustomerBirthday { get; set; }

    public bool? CustomerStatus { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<BookingReservation> BookingReservations { get; set; } = new List<BookingReservation>();
}
