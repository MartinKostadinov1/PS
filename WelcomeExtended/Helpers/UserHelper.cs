using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers;

public static class UserHelper
{
    public static string ToString(this User user)
    {
        return $"Id: {user.Id}, Email: {user.Email}, Name: {user.Name}, Role: {user.Role}, Expires: {user.Expires.ToShortDateString()}";
    }

    public static bool ValidateUser(this UserData userData, string name, string password)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("The name cannot be empty");
        }
        
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new Exception("The password cannot be empty");
        }

        return userData.ValidateUser(name, password);
    }


    public static User? GetUser(this UserData userData, string name, string password)
    {
        return userData.GetUser(name, password);
    }
}