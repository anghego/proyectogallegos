using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectogallegos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EliminarDatoUser : ContentPage
    {
        public EliminarDatoUser()
        {
            InitializeComponent();
        }

        private async void btnEliminarUser_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                var url = "http://192.168.100.236/proyectogallegos/usuario.php";
                var id = txtEliminarUser.Text;
                var uri = new Uri(string.Format(url + "?idUsuario=" + id));
                var respuesta = await cliente.DeleteAsync(uri);
                if (respuesta.IsSuccessStatusCode)
                {
                    await DisplayAlert("Alerta", "Eliminado correctamente: ", "Ok");

                }
                else
                {
                    await DisplayAlert("alerta", "ERROR:: ", "ok");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", "Error: " + ex.Message, "ok");
            }
        }

        private async void btnRegresarUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu());
        }
    }
}