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
        var fileLog = new ActionOnError(Delegates.LogToFile);
        var dbLog = new ActionOnError(Delegates.LogToDb);
        
        var user = new User
        (
            "student",
            "student@tu-sofia.bg",
            "123",
            UserRolesEnum.STUDENT,
            null
        );

        var user2 = new User
        (
            "Student2",
            "student2@tu-sofia.bg",
            "123",
            UserRolesEnum.STUDENT,
            null
        );
        
        var user3 = new User
        (
            "Teacher",
            "teacher@tu-sofia.bg",
            "1234",
            UserRolesEnum.PROFESSOR,
            null
        );
        
        var user4 = new User
        (
            "Admin",
            "admin@tu-sofia.bg",
            "12345",
            UserRolesEnum.ADMIN,
            null
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

            var message = "";
            if (UserHelper.ValidateUser(userData, name, password))
            {
                Console.WriteLine(UserHelper.ToString(UserHelper.GetUser(userData, name, password)));

                message = $"Login successful for user {name}!";
            }
            else
            {
                message = "User not found!";
            }

            log(message);
            fileLog("Login not successful!");
            dbLog("Login not successful!");

    }
}