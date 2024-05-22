
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class HotelLogModel

{

    //THIS ARE THE COLUMN OF THE DATABASE
    [Key]
    public int id { get; set; }
    public string customer_id_fk { get; set; }
    public string room_id_fk { get; set; }
    public string status { get; set; }
}
