using AppMaui.ViewModels;

namespace AppMaui.Views;

public partial class AddView : ContentPage
{
	public AddView(AddViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}