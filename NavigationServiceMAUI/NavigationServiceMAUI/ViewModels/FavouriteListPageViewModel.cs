using NavigationServiceMAUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationServiceMAUI.ViewModels
{
    public partial class FavouriteListPageViewModel : BaseViewModel
    {
       
        public FavouriteListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }
    }
}
