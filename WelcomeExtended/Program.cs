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

        var log = new ActionOnEvent(Delegates.Log);
        var fileLog = new ActionOnEvent(Delegates.LogToFile);
        var dbLog = new ActionOnEvent(Delegates.LogToDb);

        var logError = new ActionOnError(Delegates.LogError);
        var fileLogError = new ActionOnError(Delegates.LogErrorToFile);
        var dbLogError = new ActionOnError(Delegates.LogErrorToDb);

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

        try
        {
            var message = "";
            if (UserHelper.ValidateUser(userData, name, password))
            {
                Console.WriteLine(UserHelper.ToString(UserHelper.GetUser(userData, name, password)));

                message = $"Login successful for user {name}!";
                log(message);
                fileLog(message);
                dbLog(message);
            }
            else
            {
                message = "User not found!";
                logError(message);
                fileLogError(message);
                dbLogError(message);
            }
            

        }
        catch(Exception e)
        {
            logError(e.Message);
            fileLogError(e.Message);
            dbLogError(e.Message);
        }
           

    }
}