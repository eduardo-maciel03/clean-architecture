using AppMaui.ViewModels;

namespace AppMaui.Views;

public partial class EditView : ContentPage
{
    private readonly EditViewModel _viewModel;
    public EditView(EditViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = this._viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetUserToUpdateCommand.Execute(null);
    }
}