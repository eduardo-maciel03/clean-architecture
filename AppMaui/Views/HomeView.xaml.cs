using AppMaui.ViewModels;

namespace AppMaui.Views;

public partial class HomeView : ContentPage
{
	HomeViewModel _viewModel;
	public HomeView(HomeViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = this._viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_viewModel.RefreshUsernameCommand.Execute(null);
    }
}