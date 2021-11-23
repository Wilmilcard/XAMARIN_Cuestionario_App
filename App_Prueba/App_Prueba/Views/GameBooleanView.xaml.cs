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
    public partial class GameBooleanView : ContentPage
    {
        public GameBooleanView()
        {
            InitializeComponent();
            BindingContext = new GameBooleanModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(((App)Application.Current).Respuestas.Count() == 10)
                await Navigation.PushModalAsync(new NavigationPage(new ScoreView()));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (((App)Application.Current).Respuestas.Count() == 10)
                await Navigation.PushModalAsync(new NavigationPage(new ScoreView()));
        }
    }
}