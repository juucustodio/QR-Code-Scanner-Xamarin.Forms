using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OpenScanner(object sender, EventArgs e)
        {
            Scanner();
        }

        public async void Scanner()
        {

            var ScannerPage = new ZXingScannerPage();

            ScannerPage.OnScanResult += (result) => {
                // Parar de escanear
                ScannerPage.IsScanning = false;

                // Alert com o código escaneado
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Código escaneado", result.Text, "OK");
                });
            };

            
            await Navigation.PushAsync(ScannerPage);

        }
    }
}
