using NavigationServiceMAUI.Models;
using NavigationServiceMAUI.Services;
using NavigationServiceMAUI.ViewModels;
using Newtonsoft.Json;
using System.Collections.ObjectModel;


namespace NavigationServiceMAUI.Views;

public partial class StudentListPage : ContentPage
{
    public static ObservableCollection<StudentModel> ListaActores { get; set; } = new ObservableCollection<StudentModel>();
    public StudentListPage(StudentListPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    private void InnerSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        var parametro = sender as SearchBar;
        var parametro2 = parametro.SearchCommandParameter as string;

        API actor = new API();
        var filtro = "&include_adult=false&language=es&page=1";
        string resultado = actor.GetAPI("person/popular", filtro);


        if (parametro2 != string.Empty)
        {
            ListaActores.Clear();
            filtro = $"&query={parametro2}&include_adult=false&language=es&page=1";
            resultado = actor.GetAPI($"search/person", filtro);

            var listaRetorno = JsonConvert.DeserializeObject<StudentList>(resultado);

            //ordena por popularidad
            var listaRetorno2 = listaRetorno.Results.OrderByDescending(x => x.Popularity).ToList();

            foreach (var student in listaRetorno2)
            {

                if (student.ProfilePath == null)
                {
                    student.ProfilePath = "https://media.istockphoto.com/id/519078721/es/foto/macho-silhouette-como-avatar-imagen-de-perfil.jpg?s=612x612&w=0&k=20&c=VHZ-BT56AGvCY3PUdrpLHaXmoLQpXhHvjrWUf4U94iY=";
                }
                else
                {
                    student.ProfilePath = "https://image.tmdb.org/t/p/w780/" + student.ProfilePath;

                }
                ListaActores.Add(student);

            }

        }
        else
        {
            ListaActores.Clear();
            resultado = actor.GetAPI("person/popular", filtro);

            var listaRetorno = JsonConvert.DeserializeObject<StudentList>(resultado);

            listaRetorno.Results.ForEach(y => y.ProfilePath = "https://image.tmdb.org/t/p/w780/" + y.ProfilePath);
            listaRetorno.Results.ForEach(x => ListaActores.Add(x));

        }
    }
}