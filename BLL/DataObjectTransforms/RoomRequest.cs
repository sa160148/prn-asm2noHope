using System.ComponentModel.DataAnnotations;

namespace BLL.DataObjectTransforms;

public class RoomRequest
{
    
}
public class RoomCreateRequest
{
    [Required(ErrorMessage = "Room number is required")]
    public string RoomNumber { get; set; }
    
    public int RoomTypeId { get; set; }
    public int PricePerDay { get; set; }
    public int MaxCapacity { get; set; }
}

public class RoomModifyRequest
{
    public int? Id { get; set; }
    public string? RoomNumber { get; set; }
    public int? RoomTypeId { get; set; }
    public int? PricePerDay { get; set; }
    public int? MaxCapacity { get; set; }
    public string? DetailDescription { get; set; }
    public bool? Status { get; set; }
}