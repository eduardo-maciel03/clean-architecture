using AppMaui.ViewModels;

namespace AppMaui.Views;

public partial class HomeView : ContentPage
{
	public HomeView(HomeViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}