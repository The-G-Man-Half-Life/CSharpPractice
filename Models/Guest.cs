using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeC_.Models;

[Table("Guests")]
public class Guest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id {get; set;}

    [Column("name")]
    public string Name {get; set;}
    
    [Column("last_name")]
    public string LastName {get; set;}

    [Column("email")]
    public string Email {get; set;}

    [Column("identification_number")]
    public string IdentificationNumber {get; set;}

    [Column("phone_number")]
    public string PhoneNumber {get; set;}

    [Column("birthdate")]
    public DateOnly Birthdate {get; set;}


    public Guest(string Name,string LastName,string Email,string IdentificationNumber,string PhoneNumber,DateOnly Birthdate)
    {
        this.Name = Name;
        this.LastName = LastName;
        this.Email = Email;
        this.IdentificationNumber = IdentificationNumber;
        this.PhoneNumber = PhoneNumber;
        this.Birthdate = Birthdate;
    }

    public Guest() {}
}