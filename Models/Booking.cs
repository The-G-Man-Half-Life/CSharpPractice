using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeC_.Models;

[Table("Bookings")]
public class Booking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("start_date")]
    public DateTime StartDate { get; set; }

    [Column("end_date")]
    public DateTime EndDate { get; set; }

    [Column("total_cost")]
    public double TotalCost { get; set; }


    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public Employee? Employee {get; set;}


    [Column("guest_id")]
    public int GuestId { get; set; }

    [ForeignKey(nameof(GuestId))]
    public Guest? Guest {get; set;}


    [Column("room_id")]
    public int RoomId { get; set; }

    [ForeignKey(nameof(RoomId))]
    public Room? Room {get; set;}

    public Booking(DateTime StartDate,DateTime EndDate,double TotalCost,int EmployeeId,int GuestId,int RoomId)
    {
        this.StartDate = StartDate;
        this.EndDate = EndDate;
        this.TotalCost = TotalCost;
        this.EmployeeId = EmployeeId;
        this.GuestId = GuestId;
        this.RoomId = RoomId;
    }

    public Booking() { }
}