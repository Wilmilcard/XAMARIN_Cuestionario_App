using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_Prueba.Views;
using App_Prueba.Models;
using System.Collections.ObjectModel;

namespace App_Prueba
{
    public partial class App : Application
    {
        public ObservableCollection<Question> ListaPreguntas = new ObservableCollection<Question>();
        public ObservableCollection<Answer> Respuestas = new ObservableCollection<Answer>();
        public int Dificultad = 1;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PrincipalView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
