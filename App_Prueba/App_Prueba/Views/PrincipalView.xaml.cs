using App_Prueba.Clases;
using App_Prueba.Models;
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
    public partial class PrincipalView : ContentPage
    {
        public PrincipalView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient rest = new RestClient();
                var rpta = await rest.Get<Result>();
                if (rpta != null)
                    this.txt.Text = rpta.results[2].category;
            });
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new GameView
            //{
            //    BindingContext = new GameView()
            //});

            await Navigation.PushAsync(new NavigationPage(new GameView()));
        }

        async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ScoreView()));
        }
    }
}