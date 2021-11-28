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
    public partial class GameChoiseView : ContentPage
    {
        public GameChoiseView()
        {
            InitializeComponent();
            BindingContext = new GameChoiseViewModel();
        }

        private async void FloatingActionButton_Clicked(object sender, TappedEventArgs e)
        {
            this.FloatingActionButton2.IsSelected = true;
            this.FloatingActionButton3.IsSelected = true;
            this.FloatingActionButton4.IsSelected = true;

            if (((App)Application.Current).Respuestas.Count() == 10)
                await Navigation.PushModalAsync(new NavigationPage(new ScoreView()));
        }

        private async void FloatingActionButton2_Clicked(object sender, TappedEventArgs e)
        {
            this.FloatingActionButton.IsSelected = true;
            this.FloatingActionButton3.IsSelected = true;
            this.FloatingActionButton4.IsSelected = true;

            if (((App)Application.Current).Respuestas.Count() == 10)
                await Navigation.PushModalAsync(new NavigationPage(new ScoreView()));
        }

        private async void FloatingActionButton3_Clicked(object sender, TappedEventArgs e)
        {
            this.FloatingActionButton2.IsSelected = true;
            this.FloatingActionButton.IsSelected = true;
            this.FloatingActionButton4.IsSelected = true;

            if (((App)Application.Current).Respuestas.Count() == 10)
                await Navigation.PushModalAsync(new NavigationPage(new ScoreView()));
        }

        private async void FloatingActionButton4_Clicked(object sender, TappedEventArgs e)
        {
            this.FloatingActionButton2.IsSelected = true;
            this.FloatingActionButton3.IsSelected = true;
            this.FloatingActionButton.IsSelected = true;

            if (((App)Application.Current).Respuestas.Count() == 10)
                await Navigation.PushModalAsync(new NavigationPage(new ScoreView()));
        }
    }
}