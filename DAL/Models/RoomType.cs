using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class RoomType : GenericModel
{
    /*public int Id { get; set; }*/

    public string TypeName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
