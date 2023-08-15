
using NavigationServiceMAUI.Models;
using NavigationServiceMAUI.ViewModels;
using System.Collections.ObjectModel;

namespace NavigationServiceMAUI.Views;

public partial class MovieDetailPage : ContentPage
{
    public ObservableCollection<MovieModel> FavouriteList { get; set; } = FavouriteMovieListPageViewModel.FavouriteMovieList;

    public MovieModel pelicula = MovieDetailPageViewModel.peli;

   
    public MovieDetailPage(MovieDetailPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;



    }

    protected override void OnAppearing()
    {
        base.OnAppearing();



        foreach (var item in this.FavouriteList)
        {
            if (item.Id == pelicula.Id)
            {
                botoncito.TextColor = Color.FromRgb(235, 0, 0);
                botoncito.Text = "Eliminar de favoritos";
                botoncito.FontAttributes = FontAttributes.Bold;
                
            }
            
        }

       

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
            webView.Source = new UrlWebViewSource { Url = youtubeEmbedUrl };

        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var boton = sender as Button;  

        if(boton.Text == "Eliminar de favoritos")
        {

            try
            {
                foreach (var item in this.FavouriteList)
                {
                    if (item.Id == pelicula?.Id)
                    {
                        FavouriteList.Remove(item);
                        FavouriteMovieListPageViewModel.FavouriteMovieList = FavouriteList;
                    }
                }
            }
            catch
            {

            }
            
            await ReverseButton(botoncito);
        }
        else
        {  
            FavouriteList.Add(pelicula);
            FavouriteMovieListPageViewModel.FavouriteMovieList = FavouriteList;

            await RealizarAnimacionBoton(sender as Button);
        }

        
    }

    private async Task RealizarAnimacionBoton(Button boton)
    {
        await boton.ScaleTo(1.2, 100);
        await boton.ScaleTo(1, 100);
        boton.TextColor = Color.FromRgb(235, 0, 0);
        boton.Text = "Eliminar de favoritos";
        boton.FontAttributes = FontAttributes.Bold;
    }

    private async Task ReverseButton(Button boton)
    {
        await boton.ScaleTo(1.2, 100);
        await boton.ScaleTo(1, 100);
        boton.TextColor = Color.FromRgb(235, 165, 7);
        boton.Text = "Agregar a favoritos";
        boton.FontAttributes = FontAttributes.Bold;
    }
}