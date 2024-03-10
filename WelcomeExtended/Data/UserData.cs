using Welcome.Helpers;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data;

public class UserData
{
    private List<User> _users;
    private int _nextId;

    public UserData()
    {
        _nextId = 0;
        _users = new List<User>();
    }
    
    public User AddUser(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
        return user;
    }

    public bool DeleteUser(User user)
    {
        return _users.Remove(user);
    }

    public bool ValidateUser(string name, string password)
    {
        foreach (var user in _users)
        {
            if (user.Name == name && user.Password == password.Crypt())
            {
                return true;
            }
        }

        return false;
    }

    public bool ValidateUserLambda(string name, string password)
    {
        return _users
            .FirstOrDefault(x => x.Name == name && x.Password == password.Crypt()) != null ? true : false;
    }


    public bool ValidateUserLinq(string name, string password)
    {
        var ret = from user in _users
            where user.Name == name && user.Password == password.Crypt()
                  select user.Id;
        
        return ret.FirstOrDefault() != null ? true : false;
    }
    
    public User? GetUser(string name, string password)
    {
        var ret = from user in _users
            where user.Name == name && user.Password == password.Crypt()
            select user;

        return ret.FirstOrDefault();
    }

    public bool SetActive(string name, DateTime dateTime)
    {
        var ret = from user in _users
            where user.Name == name
            select user.Id;

        int? userId = ret.FirstOrDefault();
        if (userId != null && _users[(int)userId].Expires > dateTime)
        {
            _users[(int)userId].Expires = dateTime;
            return true;
        } 

        return false;

    }
    
    
    public bool AssignRole(string name, UserRolesEnum role)
    {
        var ret = from user in _users
            where user.Name == name
            select user.Id;

        int? userId = ret.FirstOrDefault();
        if (userId != null && _users[(int)userId].Role != role)
        {
            _users[(int)userId].Role = role;
            return true;
        } 

        return false;
    }

    

}