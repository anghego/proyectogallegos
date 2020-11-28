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
    public partial class Expedicion : ContentPage

    {
        private const string Url = "http://192.168.100.236/proyectogallegos/expedicion.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<proyectogallegos.Models.Expedicion> _post;
        public Expedicion()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<proyectogallegos.Models.Expedicion> posts = JsonConvert.DeserializeObject<List<proyectogallegos.Models.Expedicion>>(content);
                _post = new ObservableCollection<proyectogallegos.Models.Expedicion>(posts);

                MyListViewExp.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "ERROR " + ex.Message, "OK");
            }
        }


        private async void btnInsertarExp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InsertarDatoExp());
        }

        private async void btnActualizarExp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizarDatoExp());
        }

        private async void btnEliminarExp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarDatoExp());
        }
    }
}