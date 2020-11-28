using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectogallegos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertarDatoSitio : ContentPage
    {
        public InsertarDatoSitio()
        {
            InitializeComponent();
        }

        private async void btnInsertarSitio_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("idSitio", txtIdSitio.Text);
                parametros.Add("nombreSitio", txtNombreSitio.Text);
                parametros.Add("localidad", txtLocalidad.Text);
                parametros.Add("ciudad", txtCiudad.Text);
                parametros.Add("altitud", txtAltitud.Text);
                parametros.Add("foto", txtFoto.Text);
                parametros.Add("longitudx", txtLongitudx.Text);
                parametros.Add("longitudy", txtLongitudy.Text);
                parametros.Add("estadoSitio", txtEstadoSitio.Text);
                cliente.UploadValues("http://192.168.100.236/proyectogallegos/sitio.php", "POST", parametros);
                await DisplayAlert("Alerta", "Dato ingresado correctamente", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "ERROR: " + ex.Message, "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu());
        }
    }
}