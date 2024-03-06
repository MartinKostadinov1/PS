using Welcome.Others;

namespace Welcome.Model;

public class User
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public UserRolesEnum Role { get; set; }
    
    public DateTime Expires { get; set; }
    

    public User(string name, string password, UserRolesEnum role)
    {
        Id = null;
        Name = name;
        Password = password;
        Role = role;
        Expires = DateTime.Now.AddDays(10);
    }
}