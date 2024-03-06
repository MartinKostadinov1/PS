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
        Console.WriteLine($"Welcome\nUser:{_viewModel.Name}\nRole:{_viewModel.Role}");
    }
    
    public void DisplayError()
    {
        throw new Exception("Something went wrong!");
    }
}