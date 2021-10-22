using App_Prueba.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Prueba.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreView : ContentPage
    {
        public ScoreView()
        {
            InitializeComponent();
            BindingContext = new ScoreViewModel();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => await Navigation.PopModalAsync());
            Device.BeginInvokeOnMainThread(async () => await Navigation.PopModalAsync());

            //await Navigation.PushAsync(new PrincipalView());
        }
    }
}