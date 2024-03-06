using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Others;

namespace WelcomeExtended;

class Program
{
    static void Main(string[] args)
    {
        UserData userData = new UserData();

        var log = new ActionOnError(Delegates.Log);
        
        var user = new User
        (
            "student",
            "123",
            UserRolesEnum.STUDENT
        );

        var user2 = new User
        (
            "Student2",
            "123",
            UserRolesEnum.STUDENT
        );
        
        var user3 = new User
        (
            "Teacher",
            "1234",
            UserRolesEnum.PROFESSOR
        );
        
        var user4 = new User
        (
            "Admin",
            "12345",
            UserRolesEnum.ADMIN
        );

        userData.AddUser(user);
        userData.AddUser(user2);
        userData.AddUser(user3);
        userData.AddUser(user4);

        string name, password;
        
        Console.WriteLine("Enter name: ");
        name = Console.ReadLine();
        
        Console.WriteLine("Enter password: ");
        password = Console.ReadLine();

        if (UserHelper.ValidateUser(userData, name, password))
        {
            Console.WriteLine(UserHelper.ToString(UserHelper.GetUser(userData, name, password)));
        }
        else
        {
            log("User not found!");
        }
        
        



    }
}