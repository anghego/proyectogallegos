using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectogallegos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarDatoSitio : ContentPage
    {
        public ActualizarDatoSitio()
        {
            InitializeComponent();
        }

        private async void btnActualizarSitio_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Url = "http://192.168.100.236/proyectogallegos/sitio.php";
                HttpClient cliente = new HttpClient();
                var uri = new UriBuilder(Url);
                var parametros = HttpUtility.ParseQueryString(uri.Query);
                parametros["idSitio"]= txtIdSitioAct.Text;
                parametros["nombreSitio"]= txtNombreSitioAct.Text;
                parametros["localidad"]= txtLocalidadAct.Text;
                parametros["ciudad"]= txtCiudadAct.Text;
                parametros["altitud"]= txtAltitudAct.Text;
                parametros["foto"]= txtFotoAct.Text;
                parametros["longitudx"]= txtLongitudxAct.Text;
                parametros["longitudy"]= txtLongitudyAct.Text;
                parametros["estadoSitio"]= txtEstadoSitioAct.Text;

                uri.Query = parametros.ToString();
                var response = await cliente.PutAsync(uri.ToString(), null);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Alerta", "Actualizado correctamente: ", "Ok");

                }
                else
                {
                    await DisplayAlert("Alerta", "ERROR:: ", "Ok");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", "Error: " + ex.Message, "ok");
            }
        }

        private async void btnRegresarSitio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu());
        }
    }


}