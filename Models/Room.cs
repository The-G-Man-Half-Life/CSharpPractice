using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeC_.Models;

[Table("Rooms")]
public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("room_number")]
    public string RoomNumber { get; set; }

    [Column("price_per_night")]
    public double PricePerNight { get; set; }

    [Column("availability")]
    public Boolean Availability { get; set; }

    [Column("max_occupancy_people")]
    public byte MaxOccupancyPeople { get; set; }


    [Column("room_type_id")]
    public int RoomTypeId { get; set; }

    [ForeignKey(nameof(RoomTypeId))]
    public Room_type? Room_Type {get; set;}


    public Room(string RoomNumber,double PricePerNight,Boolean Availability,byte MaxOccupancyPeople,int RoomTypeId
    )
    {
        this.RoomNumber = RoomNumber;
        this.PricePerNight = PricePerNight;
        this.Availability = Availability;
        this.MaxOccupancyPeople = MaxOccupancyPeople;
        this.RoomTypeId = RoomTypeId;
    }

    public Room() { }
}