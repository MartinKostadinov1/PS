using Welcome.ViewModel;

namespace Welcome.View;

public class UserView
{
    private UserViewModel _viewModel;

    public UserView(UserViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public void Display()
    {
        Console.WriteLine($"\nWelcome\nUser: {_viewModel.Name}\nRole: {_viewModel.Role}");
    }
    
    public void DisplayUserWithEmail()
    {
        Console.WriteLine($"\nYour Email is: {_viewModel.Email}\nYour Name is: {_viewModel.Name}");
    }

    public void DisplayUserWithPasswordCrypt()
    {
        Console.WriteLine($"\nYour Email is: {_viewModel.Email}\nYour Password is: {_viewModel.PasswordCrypt}");
    }
    
    public void DisplayUserWithPasswordDecrypt()
    {
        Console.WriteLine($"\nProceed with caution!\nYour Email is: {_viewModel.Email}\nYour Password is: {_viewModel.PasswordDecrypt}");
    }
    
    public void DisplayError()
    {
        throw new Exception("Something went wrong!");
    }
}