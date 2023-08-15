using NavigationServiceMAUI.Models;
using NavigationServiceMAUI.ViewModels;

namespace NavigationServiceMAUI.Views;

public partial class FavMovieDetailPage : ContentPage
{
	public FavMovieDetailPage(FavouriteMovieDetailPageViewModel viewModel) 
	{
		InitializeComponent();
		this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadTrailer();
    }

    private void LoadTrailer()
    {
        string? youtubeEmbedUrl = null;
        MovieTrailerModel trailer = MovieDetailPageViewModel.MovieTrailerList.FirstOrDefault();

        if (trailer != null)
        {
            youtubeEmbedUrl = trailer.Key;
        }

        if (youtubeEmbedUrl != null || youtubeEmbedUrl != string.Empty)
        {
            trailerView.Source = new UrlWebViewSource { Url = youtubeEmbedUrl };
        }
    }
}