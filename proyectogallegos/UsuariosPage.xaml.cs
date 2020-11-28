using Newtonsoft.Json;
using proyectogallegos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectogallegos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuariosPage : ContentPage
    {
       
        private const string Url = "http://192.168.100.236/proyectogallegos/usuario.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<proyectogallegos.Models.Usuario> _post;

        public UsuariosPage()
        {
            InitializeComponent();
            get();      
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<proyectogallegos.Models.Usuario> posts = JsonConvert.DeserializeObject<List<proyectogallegos.Models.Usuario>>(content);
                _post = new ObservableCollection<proyectogallegos.Models.Usuario>(posts);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "ERROR " + ex.Message, "OK");
            }
        }

        private async void btnInsertarUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InsertarDatoUser());
        }

        private async void btnActualizarUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizarDatoUser());

        }

        private async void btnEliminarUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarDatoUser());
        }
    }
}