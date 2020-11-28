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
    public partial class ActualizarDatoExp : ContentPage
    {
        public ActualizarDatoExp()
        {
            InitializeComponent();
        }

        private async void btnActualizarExp_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Url = "http://192.168.100.236/proyectogallegos/expedicion.php";
                HttpClient cliente = new HttpClient();
                var uri = new UriBuilder(Url);
                var parametros = HttpUtility.ParseQueryString(uri.Query);
                parametros["idExpedicion"] = txtIdExpedicionAct.Text;
                parametros["actividad"] = txtActividadAct.Text;
                parametros["fecha"] = txtFechaAct.Text;
                parametros["duracion"] = txtDuracionAct.Text;
                parametros["edadMinima"] = txtEdadMinimaAct.Text;
                parametros["costo"] = txtCostoAct.Text;
                parametros["nivel"] = txtNivelAct.Text;
                parametros["estadoExpedicion"] = txtEstadoExpedicionAct.Text;
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

        private async void btnRegresarExp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu());
        }
    }

   
}