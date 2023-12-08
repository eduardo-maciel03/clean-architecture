using AppMaui.ViewModels;

namespace AppMaui.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}