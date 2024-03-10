using Welcome.Helpers;
using Welcome.Others;

namespace Welcome.Model;

public class User
{
    public virtual int? Id { get; set; }
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    private string _password;
    public string Password
    {
        get => _password;
        set => _password = value.Crypt();
    }
    public UserRolesEnum Role { get; set; }
    
    public DateTime Expires { get; set; }

    public string GetDecryptPassword => Password.Decrypt();


    public User()
    {
    }


    public User(string name, string email, string password, UserRolesEnum role, DateTime? expires)
    {
        Id = null;
        Name = name;
        Email = email;
        Password = password;
        Role = role;
        Expires = expires ?? DateTime.Now.AddDays(10);
    }
    
}