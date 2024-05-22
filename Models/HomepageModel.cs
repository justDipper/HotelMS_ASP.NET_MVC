
using System.ComponentModel.DataAnnotations;

public class HomepageModel
{
    //THIS ARE THE COLUMN OF THE DATABASE
    [Key]
    public int bookingId { get; set; }
    public string customerId { get; set; }
    public string username { get; set; }
    public string fullName { get; set; }
    public string gender { get; set; }
    public string roomId { get; set; }
    public string roomPrice { get; set; }
    public string roomStatus { get; set; }
    public string bookingStatus { get; set; }
}