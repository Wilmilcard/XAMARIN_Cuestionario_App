using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace App_Prueba.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreditsView : ContentPage
    {
        public CreditsView()
        {
            InitializeComponent();
            this.lblText.Text = "This application was developed in\n" +
                                " Xamarin Forms and C# applying\n" +
                                "       the MVVM layout pattern.\n\n" +
                                "   Design was also implemented \n" +
                                "  with exclusive Xamarin libraries \n" +
                                "    and creating custom controls.";
        }

        private async void Git(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://github.com/Wilmilcard", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async void web(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://nevergate.com.co/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async void linkelind(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.linkedin.com/in/juan-david-leon-barrera-20a0451a8/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async void YouTube(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.youtube.com/channel/UCzAhs3CL7Kjq49jjeJVDeJg", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async void special1(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://github.com/jesulink2514", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async void special2(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://github.com/mono", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async void special3(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://github.com/luberda-molinet", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async void special4(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://fontawesome.com/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async void special5(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://opentdb.com/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async void special6(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.linkedin.com/in/juana-sherley-bravo-castro-590201170/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        private void back(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => await Navigation.PopModalAsync());
        }
    }
}