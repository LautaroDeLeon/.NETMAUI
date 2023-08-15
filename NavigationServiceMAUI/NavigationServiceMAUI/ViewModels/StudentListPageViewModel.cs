
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
    public partial class StudentListPageViewModel : BaseViewModel
    {
        public IDictionary<string, object> parametersAux;
        public ObservableCollection<StudentModel> StudentList { get; set; } = StudentListPage.ListaActores;
        public ObservableCollection<infoActor> BusquedaActor { get; set; } = new ObservableCollection<infoActor>();      


        public StudentListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            AddStudentDetails();
        }
        public StudentListPageViewModel() { }
        private void AddStudentDetails()
        {
            API actores = new API();
            var filtro = "&include_adult=false&language=es&page=1";
            string resultado = actores.GetAPI("person/popular", filtro);
            var listaRetorno = JsonConvert.DeserializeObject<StudentList>(resultado);
            listaRetorno.Results.ForEach(x => x.ProfilePath = "https://image.tmdb.org/t/p/w780/" + x.ProfilePath);
            listaRetorno.Results.ForEach(x => StudentList.Add(x));

        }


        [RelayCommand]
        public void StudentSelected(StudentModel student)
        {
            API actoresInfo = new API();//------------
            var filtro = "&include_adult=false&language=es&page=1";
            var aux = actoresInfo.GetAPI("person/" + student.Id, filtro);
            var aux2 = JsonConvert.DeserializeObject<infoActor>(aux);
            aux2.ProfilePath = "https://image.tmdb.org/t/p/w780/" + aux2.ProfilePath;
            BusquedaActor.Add(aux2);
            var student2 = aux2;


            NavigationService.NavigateToAsync(nameof(StudentDetailPage), new Dictionary<string, object> { { "StudentDetail", student2 } });
        }

        [RelayCommand]

        public void Search(string busqueda)
        {
            API actores = new API();
            var filtro = "&include_adult=false&language=es&page=1";
            string resultado = actores.GetAPI("person/popular", filtro);

            StudentList.Clear();

            if (busqueda != "")
            {
                filtro = $"&query={busqueda}&include_adult=false&language=es&page=1";
                resultado = actores.GetAPI($"search/person", filtro);

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
                    StudentList.Add(student);

                }
            }
            else
            {
                resultado = actores.GetAPI("person/popular", filtro);

                var listaRetorno = JsonConvert.DeserializeObject<StudentList>(resultado);

                listaRetorno.Results.ForEach(y => y.ProfilePath = "https://image.tmdb.org/t/p/w780/" + y.ProfilePath);
                listaRetorno.Results.ForEach(x => StudentList.Add(x));

            }


        }
    }
}
