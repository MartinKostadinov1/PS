using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;


namespace Welcome;

class Program
{
    static void Main(string[] args)
    {
        User AdminUser = new User("Martin", "martin@example.com", "martin123", UserRolesEnum.ADMIN, null);
        UserViewModel ViewModel = new UserViewModel(AdminUser);
        UserView UserView = new UserView(ViewModel);
        
        UserView.Display();
        UserView.DisplayUserWithEmail();
        UserView.DisplayUserWithPasswordCrypt();
        UserView.DisplayUserWithPasswordDecrypt();
        
    }
}