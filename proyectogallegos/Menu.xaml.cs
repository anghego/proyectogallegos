using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectogallegos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private async void btnUsuario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsuariosPage());
        }

        private async void btnSitio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sitio());
        }

        private async void btnExpedicion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Expedicion());
        }

        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}