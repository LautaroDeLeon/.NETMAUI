using CommunityToolkit.Mvvm.ComponentModel;
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
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]
    public partial class StudentDetailPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private infoActor _studentDetail;

        long? _idActor;

        public IDictionary<string, object> parametersAux;
        public ObservableCollection<MovieCredits> pelisDelActor { get; set; } = new ObservableCollection<MovieCredits>();

        public StudentDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            parametersAux = navigationService.GetParameters();

            var objeto = parametersAux.Values.FirstOrDefault(x => x.GetType().GetProperty("Id")?.PropertyType == typeof(long?));

            if (objeto != null)
            {
                _idActor = (long?)objeto.GetType().GetProperty("Id").GetValue(objeto);

            }

            traerPelis(_idActor);
        }

        public void traerPelis(long? id)
        {
            pelisDelActor.Clear();

            API pelis = new API();

            var filtro = "&include_adult=false&language=es&page=1";

            var endpoint = pelis.GetAPI($"person/{id}/movie_credits", filtro);
            var listaRetorno = JsonConvert.DeserializeObject<MovieCreditsList>(endpoint);

            var lista2 = listaRetorno.Cast.OrderByDescending(x => x.Popularity).ToList();
            lista2 = lista2.Take(5).ToList();
           

            lista2.ForEach(y => y.PosterPath = "https://image.tmdb.org/t/p/w780/" + y.PosterPath);
            lista2.ForEach(x => pelisDelActor.Add(x));
            

        }

        [RelayCommand]
        public void MovieSelected(MovieCredits movie)
        {
            var id = movie.Id;
            API api = new API();
            var filtro = "&include_adult=false&language=es&page=1";
            var endpoint = api.GetAPI($"movie/{id}", filtro);

            var peliRetorno = JsonConvert.DeserializeObject<MovieModel>(endpoint);
            peliRetorno.PosterPath = "https://image.tmdb.org/t/p/w780/" + peliRetorno.PosterPath;


            NavigationService.NavigateToAsync(nameof(MovieDetailPage), new Dictionary<string, object> { { "Favorito", peliRetorno } });
        }
    }
}
