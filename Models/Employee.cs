using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeC_.Models;

[Table("Employees")]
public class Employee
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

    [Column("password")]
    public string Password {get; set;}

    public Employee(string Name,string LastName,string Email,string IdentificationNumber,string Password)
    {
        this.Name = Name;
        this.LastName = LastName;
        this.Email = Email;
        this.IdentificationNumber = IdentificationNumber;
        this.Password = Password;
    }

    public Employee() {}
}