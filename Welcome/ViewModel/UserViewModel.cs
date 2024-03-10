using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel;

public class UserViewModel
{
    public User _user { get; set; }


    public UserViewModel(User user)
    {
        _user = user;
    }


    public string Name
    {
        get { return _user.Name; }

    }
    
    public string Email
    {
        get { return _user.Email; }

    }
    
    public string PasswordCrypt
    {
        get => _user.Password;
    }
    
    public string PasswordDecrypt
    {
        get => _user.GetDecryptPassword();
    }
    
    public UserRolesEnum Role
    {
        get { return _user.Role; }
        set { _user.Role = value; }

    }
}