using Microsoft.Extensions.Logging;
using NavigationServiceMAUI.Models;
using NavigationServiceMAUI.Services;
using NavigationServiceMAUI.ViewModels;
using NavigationServiceMAUI.Views;

namespace NavigationServiceMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<INavigationService, NavigationService>();

		//UI registration
		builder.Services.AddSingleton<AppLaunchPage>();
        builder.Services.AddTransient<StudentListPage>();
		builder.Services.AddTransient<StudentDetailPage>();
        builder.Services.AddTransient<MovieListPage>();
        builder.Services.AddTransient<MovieDetailPage>();
        builder.Services.AddTransient<FavMovieListPage>();
        builder.Services.AddTransient<FavMovieDetailPage>();

        //ViewModel registration
        builder.Services.AddSingleton<AppLaunchPageViewModel>();
        builder.Services.AddTransient<StudentListPageViewModel>();
        builder.Services.AddTransient<StudentDetailPageViewModel>();
        builder.Services.AddTransient<MovieListPageViewModel>();
        builder.Services.AddTransient<MovieDetailPageViewModel>();
        builder.Services.AddTransient<FavouriteMovieListPageViewModel>();
        builder.Services.AddTransient<FavouriteMovieDetailPageViewModel>();

        return builder.Build();
	}
}
