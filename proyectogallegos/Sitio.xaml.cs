using Newtonsoft.Json;
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
    public partial class Sitio : ContentPage
    {
        private const string Url = "http://192.168.100.236/proyectogallegos/sitio.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<proyectogallegos.Models.Sitio> _post;
        public Sitio()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<proyectogallegos.Models.Sitio> posts = JsonConvert.DeserializeObject<List<proyectogallegos.Models.Sitio>>(content);
                _post = new ObservableCollection<proyectogallegos.Models.Sitio>(posts);

                MyListViewSitio.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "ERROR " + ex.Message, "OK");
            }
        }

        private async void btnInsertarSitio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InsertarDatoSitio());
        }

        private async void btnActualizarSitio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizarDatoSitio());
        }

        private async void btnEliminarSitio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarDatoSitio());
        }
    }
}