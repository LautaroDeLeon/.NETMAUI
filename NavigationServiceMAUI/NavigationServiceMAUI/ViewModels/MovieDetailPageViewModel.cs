using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NavigationServiceMAUI.Models;
using NavigationServiceMAUI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationServiceMAUI.ViewModels
{
    [QueryProperty(nameof(MovieDetail), "Favorito")]
    public partial class MovieDetailPageViewModel : BaseViewModel
    {
        public long? _idPelicula;
        public IDictionary<string, object> parametersAux;
        public static ObservableCollection<MovieTrailerModel> MovieTrailerList { get; set; } = new ObservableCollection<MovieTrailerModel>();
        public ObservableCollection<ImageModel> MovieImagesList { get; set; } = new ObservableCollection<ImageModel>();

        [ObservableProperty]
        public static MovieModel peli;

        [ObservableProperty]
        private MovieModel _movieDetail;

        public MovieDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            parametersAux = navigationService.GetParameters();
            var objeto = parametersAux.Values.FirstOrDefault(x => x.GetType().GetProperty("Id")?.PropertyType == typeof(long?));

            if(objeto != null)
            {
                _idPelicula = (long?)objeto.GetType().GetProperty("Id").GetValue(objeto);

                AddTrailer(_idPelicula);
                AddImages(_idPelicula);
                peli = objeto as MovieModel;
            }
        }

        private void AddImages(long? id)
        {
            MovieImagesList.Clear();

            API movies = new API();
            var filtro = "&include_adult=false&language=es&page=1";
            var endpoint = movies.GetAPI($"movie/{id}/images", filtro);

            var listaRetorno = JsonConvert.DeserializeObject<ImageList>(endpoint);

            listaRetorno.Posters.ForEach(y => y.FilePath = "https://image.tmdb.org/t/p/w780/" + y.FilePath);          
            listaRetorno.Posters.ForEach(x => MovieImagesList.Add(x));
        }
        private void AddTrailer(long? id)
        {
            MovieTrailerList.Clear();

            API movies = new API();
            var filtro = "&include_adult=false&language=es&page=1";
            var endpoint = movies.GetAPI($"movie/{id}/videos", filtro);

            var listaRetorno = JsonConvert.DeserializeObject<MovieTrailer>(endpoint);
            
            foreach(var trailer in listaRetorno.Results)
            {
                if(trailer.Type == "Trailer")
                {
                    MovieTrailerList.Add(trailer);
                }
            }

            listaRetorno.Results.ForEach(peli => peli.Key = "https://www.youtube.com/embed/" + peli.Key + "?fullscreen=1");
        }

        [RelayCommand]
        public void Favoritos()
        {
            if (parametersAux != null)
            {
                FavouriteMovieListPageViewModel.FavouriteMovieList.Add(parametersAux["Favorito"] as MovieModel);
            }
        }
    }
}
