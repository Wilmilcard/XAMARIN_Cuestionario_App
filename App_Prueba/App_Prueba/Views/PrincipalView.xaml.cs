using App_Prueba.Clases;
using App_Prueba.Models;
using App_Prueba.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            BindingContext = new PrincipalViewModel();
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
            ((App)Application.Current).Dificultad = 0;
            this.choise2.IsSelected = false;
            this.choise3.IsSelected = false;
        }

        private void GradientToogleButton_Clicked_1(object sender, TappedEventArgs e)
        {
            ((App)Application.Current).Dificultad = 1;
            this.choise1.IsSelected = false;
            this.choise3.IsSelected = false;
        }

        private void GradientToogleButton_Clicked_2(object sender, TappedEventArgs e)
        {
            ((App)Application.Current).Dificultad = 2;
            this.choise1.IsSelected = false;
            this.choise2.IsSelected = false;
        }


        private void GradientToogleButton_Clicked_3(object sender, TappedEventArgs e)
        {
            ((App)Application.Current).ModeGame = 0;
            this.choiseType2.IsSelected = false;
        }

        private void GradientToogleButton_Clicked_4(object sender, TappedEventArgs e)
        {
            ((App)Application.Current).ModeGame = 1;
            this.choiseType1.IsSelected = false;
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            var rest = new RestClient();
            //var rpta = await rest.Get<Result>("https://opentdb.com/api.php?amount=10&difficulty=hard&type=boolean");
            //var rpta = await rest.Get<Result>("https://opentdb.com/api.php?amount=1&type=multiple");
            var json = "{\"error\":\"mensaje\"}";
            
            HttpClient http = new HttpClient();
            var response = await http.GetAsync("https://opentdb.com/api.php?amount=10&difficulty=hard&type=multiple");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonstring = await response.Content.ReadAsStringAsync();
                var rpta = JsonConvert.DeserializeObject<Result>(jsonstring);
            }
        }
    }
}