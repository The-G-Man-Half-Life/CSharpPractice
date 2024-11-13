using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeC_.Models;

[Table("Room_types")]
public class Room_type
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id {get; set;}

    [Column("name")]
    public string Name {get; set;}

    [Column("description")]
    public string Description {get; set;}


    public Room_type(string Name ,string Description)
    {
        this.Name = Name;
        this.Description = Description;
    }

    public Room_type() {}
}