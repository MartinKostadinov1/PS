using DataLayer.Database;
using DataLayer.Model;
using Welcome.Others;

namespace DataLayer;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new DatabaseContext())
        {
            context.Database.EnsureCreated();
            
            var users = context.Users.ToList();
            Console.WriteLine("Login");
            
            Console.WriteLine("Enter username: ");
            var username = Console.ReadLine();
            
            Console.WriteLine("Enter password: ");
            var password = Console.ReadLine();
            
            var userRecord = (from user in users
                where user.Name.Equals(username) && user.GetDecryptPassword().Equals(password)
                select user).FirstOrDefault();

            Console.WriteLine(userRecord != null ? "Successful login!" : "Unsuccessful login!");

            
            if (userRecord is { Role: UserRolesEnum.ADMIN })
            {
                string? command = "";
                while (command != null && !command.Equals("END"))
                {
                    Console.WriteLine("Welcome ADMIN. Enter command: ");
                    command = Console.ReadLine();

                    if (command != null && command.Equals("END"))
                    {
                        Console.WriteLine("Good day!");
                        return;
                    }

                    switch (command)
                    {
                        case "Add":
                            Console.WriteLine("Enter user name:");
                            var newUserName = Console.ReadLine();
                            Console.WriteLine("Enter user password:");
                            var newUserPassword = Console.ReadLine();
                            if (newUserName == null || newUserPassword == null)
                            {
                                break;
                            }
                            
                            context.Add(new DatabaseUser()
                            {
                                Name = newUserName,
                                Email = $"{newUserName}@tu-sofia.bg",
                                Password = newUserPassword,
                                Expires = DateTime.Now,
                                Role = UserRolesEnum.STUDENT,
                            });
                            
                            context.SaveChanges();
                            
                            break;
                        case "Delete":
                            Console.WriteLine("Enter user name:");
                            var name = Console.ReadLine();
                            var userToDelete = (from user in users
                                where user.Name.Equals(name)
                                select user).FirstOrDefault();

                            if (userToDelete != null)
                                context.Users.Remove(userToDelete);
                            
                            context.SaveChanges();
                            
                            break;
                        case "List":
                            foreach (var user in users)
                            {
                                Console.WriteLine(user);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid command");
                            break;
                    }
                }
            }

        }
    }
}