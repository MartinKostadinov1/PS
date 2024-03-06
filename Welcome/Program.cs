using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;


namespace Welcome;

class Program
{
    static void Main(string[] args)
    {
        User AdminUser = new User("Martin", "asd", UserRolesEnum.ADMIN);
        UserViewModel ViewModel = new UserViewModel(AdminUser);
        UserView UserView = new UserView(ViewModel);
        
        UserView.Display();
    }
}