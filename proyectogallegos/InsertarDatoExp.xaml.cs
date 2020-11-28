using Newtonsoft.Json;
using proyectogallegos.Models;
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
    public partial class InsertarDatoExp : ContentPage
    {
        public InsertarDatoExp()
        {
            InitializeComponent();
        }

        private async void btnInsertarExp_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("idExpedicion", txtIdExpedicion.Text);
                parametros.Add("actividad", txtActividad.Text);
                parametros.Add("fecha", txtFecha.Text);
                parametros.Add("duracion", txtDuracion.Text);
                parametros.Add("edadMinima", txtEdadMinima.Text);
                parametros.Add("costo", txtCosto.Text);
                parametros.Add("nivel", txtNivel.Text);
                parametros.Add("estadoExpedicion", txtEstadoExpedicion.Text);
                cliente.UploadValues("http://192.168.100.236/proyectogallegos/expedicion.php", "POST", parametros);
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