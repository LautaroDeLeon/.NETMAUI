using NavigationServiceMAUI.ViewModels;

namespace NavigationServiceMAUI.Views;

public partial class FavouriteListPage : ContentPage
{
	public FavouriteListPage(FavouriteListPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}