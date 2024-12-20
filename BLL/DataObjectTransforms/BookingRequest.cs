using DAL.Models;

namespace BLL.DataObjectTransforms;

public class BookingRequest : GenericModel
{
    public bool Status = true;
    public BookingDetailRequest? BookingDetail { get; set; }
}