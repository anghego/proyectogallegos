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
    public partial class ActualizarDatoUser : ContentPage
    {
        public ActualizarDatoUser()
        {
            InitializeComponent();
        }

        private async void btnActualizarUser_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Url = "http://192.168.100.236/proyectogallegos/usuario.php";
                HttpClient cliente = new HttpClient();
                var uri = new UriBuilder(Url);
                var parametros = HttpUtility.ParseQueryString(uri.Query);
                parametros["idUsuario"]= txtIdUsuarioAct.Text;
                parametros["usuario"]= txtUsuarioAct.Text;
                parametros["clave"]= txtClaveAct.Text;
                parametros["nombre"]= txtNombreAct.Text;
                parametros["apellido"]= txtApellidoAct.Text;
                parametros["cedula"]= txtCedulaAct.Text;
                parametros["telefono"]= txtTelefonoAct.Text;
                parametros["mail"]= txtMailAct.Text;
                parametros["estadoCliente"]= txtEstadoClienteAct.Text;
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

        private async void btnRegresarUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu());
        }
    }
}