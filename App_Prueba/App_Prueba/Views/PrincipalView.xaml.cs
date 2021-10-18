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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new GameView()));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CreditsView()));
        }

        private void GradientToogleButton_Clicked(object sender, TappedEventArgs e)
        {
            this.choise2.IsSelected = false;
            this.choise3.IsSelected = false;
        }

        private void GradientToogleButton_Clicked_1(object sender, TappedEventArgs e)
        {
            this.choise1.IsSelected = false;
            this.choise3.IsSelected = false;
        }

        private void GradientToogleButton_Clicked_2(object sender, TappedEventArgs e)
        {
            this.choise1.IsSelected = false;
            this.choise2.IsSelected = false;
        }
    }
}