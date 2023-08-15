using NavigationServiceMAUI.Views;

namespace NavigationServiceMAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(StudentListPage), typeof(StudentListPage));
        Routing.RegisterRoute(nameof(StudentDetailPage), typeof(StudentDetailPage));
        Routing.RegisterRoute(nameof(MovieListPage), typeof(MovieListPage));
        Routing.RegisterRoute(nameof(MovieDetailPage), typeof(MovieDetailPage));
        Routing.RegisterRoute(nameof(FavMovieListPage), typeof(FavMovieListPage));
        Routing.RegisterRoute(nameof(FavMovieDetailPage), typeof(FavMovieDetailPage));
    }
}
