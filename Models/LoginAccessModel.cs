
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class LoginAccessModel
{
    //THIS ARE THE COLUMN OF THE DATABASE
    [Key]
    public int id { get; set; }
    public string? customer_id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string? fullname { get; set; }
    public string? birth_date { get; set; }
    public string? address { get; set; }
    public string? gender { get; set; }
    public string? access_type { get; set; }
}
