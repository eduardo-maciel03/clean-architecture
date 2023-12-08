using AppMaui.ViewModels;

namespace AppMaui.Views;

public partial class UsersView : ContentPage
{
	private readonly UsersViewModel _viewModel;

	public UsersView(UsersViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = this._viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_viewModel.LoadUsersCommand.Execute(null);
    }
}