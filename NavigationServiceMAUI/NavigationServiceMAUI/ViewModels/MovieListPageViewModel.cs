using CommunityToolkit.Mvvm.Input;
using NavigationServiceMAUI.Models;
using NavigationServiceMAUI.Services;
using NavigationServiceMAUI.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationServiceMAUI.ViewModels
{
    public partial class MovieListPageViewModel : BaseViewModel
    {
        public IDictionary<string, object> parametersAux;
        public  ObservableCollection<MovieModel> MovieList { get; set; } = MovieListPage.Lista;
        public ObservableCollection<MovieModel> Upcoming { get; set; } = new ObservableCollection<MovieModel>();
        public ObservableCollection<MovieModel> TopRated { get; set; } = new ObservableCollection<MovieModel>();
        public MovieListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            parametersAux = navigationService.GetParameters();
     
            AddMovieDetails();      
        }
        public MovieListPageViewModel() { }


        private void AddMovieDetails()
        {
            API movies = new API();
            var filtro = "&include_adult=false&language=es&page=1";

            string resultado = movies.GetAPI("movie/popular", filtro);
            string resultado2 = movies.GetAPI("movie/upcoming", filtro);
            string resultado3 = movies.GetAPI("movie/top_rated", filtro);

            var listaRetorno = JsonConvert.DeserializeObject<MovieList>(resultado);
            var listaRetorno2 = JsonConvert.DeserializeObject<MovieList>(resultado2);
            var listaRetorno3 = JsonConvert.DeserializeObject<MovieList>(resultado3);



            listaRetorno.Results.ForEach(y => y.PosterPath = "https://image.tmdb.org/t/p/w780/" + y.PosterPath);          
            listaRetorno.Results.ForEach(x => MovieList.Add(x));

            listaRetorno2.Results.ForEach(y => y.PosterPath = "https://image.tmdb.org/t/p/w780/" + y.PosterPath);
            listaRetorno2.Results.ForEach(x => Upcoming.Add(x));

            listaRetorno3.Results.ForEach(y => y.PosterPath = "https://image.tmdb.org/t/p/w780/" + y.PosterPath);
            listaRetorno3.Results.ForEach(x => TopRated.Add(x));
        }

        [RelayCommand]
        public void MovieSelected(MovieModel movie)
        {
            NavigationService.NavigateToAsync(nameof(MovieDetailPage), new Dictionary<string, object> { { "Favorito", movie } });
        }

        [RelayCommand]
        public void Search(string busqueda)
        {
            API movies = new API();
            var filtro = "&include_adult=false&language=es&page=1";
            string resultado = movies.GetAPI("movie/popular", filtro);

            MovieList.Clear();

            

            if (busqueda != "")
            {
                
                filtro = $"&query={busqueda}&include_adult=false&language=es&page=1";
                resultado = movies.GetAPI("search/movie", filtro);           

                var listaRetorno = JsonConvert.DeserializeObject<MovieList>(resultado);

                listaRetorno.Results.ForEach(y => y.PosterPath = "https://image.tmdb.org/t/p/w780/" + y.PosterPath);
                listaRetorno.Results.ForEach(x => MovieList.Add(x));
            }
            else
            {           
                var listaRetorno = JsonConvert.DeserializeObject<MovieList>(resultado);

                listaRetorno.Results.ForEach(y => y.PosterPath = "https://image.tmdb.org/t/p/w780/" + y.PosterPath);
                listaRetorno.Results.ForEach(x => MovieList.Add(x));
            }
        }    
    }
}
