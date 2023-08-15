using NavigationServiceMAUI.Models;
using NavigationServiceMAUI.Services;
using NavigationServiceMAUI.ViewModels;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NavigationServiceMAUI.Views;

public partial class MovieListPage : ContentPage
{
    public static ObservableCollection<MovieModel> Lista { get; set; } = new ObservableCollection<MovieModel>();
    public MovieListPage(MovieListPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    private void InnerSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        var parametro = sender as SearchBar;
        var parametro2 = parametro.SearchCommandParameter as string;
        
        API movies = new API();
        var filtro = "&include_adult=false&language=es&page=1";
        string resultado = movies.GetAPI("movie/popular", filtro);

       
        if (parametro2 != string.Empty)
        {
            Lista.Clear();
            filtro = $"&query={parametro2}&include_adult=false&language=es&page=1";
            resultado = movies.GetAPI("search/movie", filtro);

            var listaRetorno = JsonConvert.DeserializeObject<MovieList>(resultado);


            var lista2 = listaRetorno.Results.OrderByDescending(x => x.Popularity).ToList();
            lista2 = lista2.Take(10).ToList();

            lista2.ForEach(y => y.PosterPath = "https://image.tmdb.org/t/p/w780/" + y.PosterPath);
            lista2.ForEach(x => Lista.Add(x));
           
        }
        else
        {
            Lista.Clear();
            resultado = movies.GetAPI("movie/popular", filtro);

            var listaRetorno = JsonConvert.DeserializeObject<MovieList>(resultado);

            listaRetorno.Results.ForEach(y => y.PosterPath = "https://image.tmdb.org/t/p/w780/" + y.PosterPath);
            listaRetorno.Results.ForEach(x => Lista.Add(x));
           
        }
    }
}