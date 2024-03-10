using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Welcome.Model;
using Welcome.Others;

namespace DataLayer.Model;

public class DatabaseUser: User
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int? Id { get; set; }

    public DatabaseUser() : base()
    {
    }

    public DatabaseUser(string name, string email, string password, UserRolesEnum role, DateTime expires) : base(name, email,
        password, role, expires)
    {
    }

    public override string ToString()
    {
        return $"Id: {Id}, Email: {Email}, Name: {Name}, Role: {Role}, Expires: {Expires.ToShortDateString()}";
    }
}