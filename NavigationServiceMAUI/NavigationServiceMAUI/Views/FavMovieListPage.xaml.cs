using NavigationServiceMAUI.ViewModels;

namespace NavigationServiceMAUI.Views;

public partial class FavMovieListPage : ContentPage
{
	public FavMovieListPage(FavouriteMovieListPageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
        FavoriteMoviesListView.ItemsSource = FavouriteMovieListPageViewModel.FavouriteMovieList;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (FavouriteMovieListPageViewModel.FavouriteMovieList.Count == 0)
        {
            labelFav.Text = "Aun no tienes películas en favoritos :(";
        }
        else
        {
            labelFav.Text = "Lista de favoritos";
        }

     
    }
}