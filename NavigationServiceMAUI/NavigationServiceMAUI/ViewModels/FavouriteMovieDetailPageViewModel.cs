using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NavigationServiceMAUI.Models;
using NavigationServiceMAUI.Services;
using Newtonsoft.Json;

namespace NavigationServiceMAUI.ViewModels
{
    [QueryProperty(nameof(MovieDetail), "Favorito")]
    public partial class FavouriteMovieDetailPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private MovieModel _movieDetail;

        public long? _idPelicula;

        public IDictionary<string, object> parametersAux;
        public static ObservableCollection<MovieTrailerModel> Trailers { get; set; } = MovieDetailPageViewModel.MovieTrailerList;

        public FavouriteMovieDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            parametersAux = navigationService.GetParameters();
            var objeto = parametersAux.Values.FirstOrDefault(x => x.GetType().GetProperty("Id")?.PropertyType == typeof(long?));

            if (objeto != null)
            {
                _idPelicula = (long?)objeto.GetType().GetProperty("Id").GetValue(objeto);

                AddTrailer(_idPelicula);
            }
        }
        private void AddTrailer(long? id)
        {
            Trailers.Clear();

            API movies = new API();
            var filtro = "&include_adult=false&language=es&page=1";
            var endpoint = movies.GetAPI($"movie/{id}/videos", filtro);

            var listaRetorno = JsonConvert.DeserializeObject<MovieTrailer>(endpoint);

            foreach (var trailer in listaRetorno.Results)
            {
                if (trailer.Type == "Trailer")
                {
                    Trailers.Add(trailer);
                }
            }

            listaRetorno.Results.ForEach(peli => peli.Key = "https://www.youtube.com/embed/" + peli.Key);
        }
    }
}
