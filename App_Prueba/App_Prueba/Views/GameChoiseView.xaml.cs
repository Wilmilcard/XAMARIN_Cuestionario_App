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

        private void FloatingActionButton_Clicked(object sender, TappedEventArgs e)
        {
            this.FloatingActionButton2.IsSelected = true;
            this.FloatingActionButton3.IsSelected = true;
            this.FloatingActionButton4.IsSelected = true;
        }

        private void FloatingActionButton2_Clicked(object sender, TappedEventArgs e)
        {
            this.FloatingActionButton.IsSelected = true;
            this.FloatingActionButton3.IsSelected = true;
            this.FloatingActionButton4.IsSelected = true;
        }

        private void FloatingActionButton3_Clicked(object sender, TappedEventArgs e)
        {
            this.FloatingActionButton2.IsSelected = true;
            this.FloatingActionButton.IsSelected = true;
            this.FloatingActionButton4.IsSelected = true;
        }

        private void FloatingActionButton4_Clicked(object sender, TappedEventArgs e)
        {
            this.FloatingActionButton2.IsSelected = true;
            this.FloatingActionButton3.IsSelected = true;
            this.FloatingActionButton.IsSelected = true;
        }
    }
}