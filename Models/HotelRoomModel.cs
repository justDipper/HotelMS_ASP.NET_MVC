
using System.ComponentModel.DataAnnotations;

public class HotelRoomModel
{

    //THIS ARE THE COLUMN OF THE DATABASE
    [Key]
    public int id { get; set; }
    public string room_id { get; set; }
    public string? room_price { get; set; }
    public string? status { get; set; }
}