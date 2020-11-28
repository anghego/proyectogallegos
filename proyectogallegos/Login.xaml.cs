using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using proyectogallegos.Models;

namespace proyectogallegos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            btnIngresar.Clicked += btnIngresar_Clicked;

        }

               
        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                await DisplayAlert("Error", "Ingrese un usuario", "Aceptar");
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtClave.Text))
            {
                await DisplayAlert("Error", "Ingrese una clave", "Aceptar");
                txtClave.Focus();
                return;
            }

            waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                btnIngresar.IsEnabled = false;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://192.168.100.236");
                string url = string.Format("proyectogallegos/usuario.php/{0}/{1}", txtUsuario.Text, txtClave.Text);
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
                btnIngresar.IsEnabled = true;
            }
            catch (Exception ex) {
                await DisplayAlert("Error", "No se puede conectar favor ingrese más tarde", "Aceptar");
                btnIngresar.IsEnabled = true;
                waitActivityIndicator.IsRunning = false;
                return;
            }
            waitActivityIndicator.IsRunning = false;

            if (string.IsNullOrEmpty (result) || result == "null")
            {
                await DisplayAlert("Error", "Usuario o clave incorracto", "Aceptar");
                txtClave.Text = string.Empty;
                txtClave.Focus();
                return;
            }
            //var usuario = JsonConvert.DeserializeObject<Usuario> (result);
            await Navigation.PushAsync(new Menu());
        }

        
    }
}