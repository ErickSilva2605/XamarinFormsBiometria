using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TesteBiometria
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private CancellationTokenSource _cancel;
        private bool _initialized;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Autenticar(object sender, EventArgs e)
        {
            var result = await CrossFingerprint.Current.IsAvailableAsync(true);

            if (result)
            {
                AuthenticationRequestConfiguration configuration = new AuthenticationRequestConfiguration("Toque no Sensor", "Acessar");

                var auth = await CrossFingerprint.Current.AuthenticateAsync(configuration);
                if (auth.Authenticated)
                {
                    Resultado.Text = "Autenticado com sucesso! :)";
                }
                else
                {
                    Resultado.Text = "Impressão digital não reconhecida";
                }
            }
            else
            {
                await DisplayAlert("Ops", "Dispositivo não suportado", "OK");
            }
        }
    }
}
