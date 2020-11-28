using Newtonsoft.Json;
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
    public partial class InsertarDatoUser : ContentPage
    {
        public InsertarDatoUser()
        {
            InitializeComponent();
        }

        private async void btnInsertarUser_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("idUsuario", txtIdUsuario.Text);
                parametros.Add("usuario", txtUsuario.Text);
                parametros.Add("clave", txtClave.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("cedula", txtCedula.Text);
                parametros.Add("telefono", txtTelefono.Text);
                parametros.Add("mail", txtMail.Text);
                parametros.Add("estadoCliente", txtEstadoCliente.Text);
                cliente.UploadValues("http://192.168.100.236/proyectogallegos/usuario.php", "POST", parametros);
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