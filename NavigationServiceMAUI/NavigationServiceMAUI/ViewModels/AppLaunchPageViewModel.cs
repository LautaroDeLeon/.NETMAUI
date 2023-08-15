using CommunityToolkit.Mvvm.Input;
using NavigationServiceMAUI.Models;
using NavigationServiceMAUI.Services;
using NavigationServiceMAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationServiceMAUI.ViewModels
{
    public partial class AppLaunchPageViewModel : BaseViewModel
    {
        public AppLaunchPageViewModel(INavigationService navigationService) : base(navigationService) 
        {
            
        }

        [RelayCommand]
        public void NavigateToStudentList()
        {
            NavigationService.NavigateToAsync(nameof(StudentListPage));
        }

        [RelayCommand]
        public void NavigateToMovieList()
        {
            NavigationService.NavigateToAsync(nameof(MovieListPage));
        }

        [RelayCommand]
        public void NavigateToFavouriteMovieList()
        {
            NavigationService.NavigateToAsync(nameof(FavMovieListPage));
        }

    }
}
