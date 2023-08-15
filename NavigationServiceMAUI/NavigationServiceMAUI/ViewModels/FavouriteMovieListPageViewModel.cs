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
    public partial class FavouriteMovieListPageViewModel : BaseViewModel
    {
        public IDictionary<string, object> parametersAux;
        public static ObservableCollection<MovieModel> FavouriteMovieList { get; set; } = new ObservableCollection<MovieModel>();

        public FavouriteMovieListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            parametersAux = navigationService.GetParameters();
        }

        public FavouriteMovieListPageViewModel() { }


        [RelayCommand]
        public void MovieSelected(MovieModel movie)
        {
            NavigationService.NavigateToAsync(nameof(MovieDetailPage), new Dictionary<string, object> { { "Favorito", movie } });
        }
    }
}
