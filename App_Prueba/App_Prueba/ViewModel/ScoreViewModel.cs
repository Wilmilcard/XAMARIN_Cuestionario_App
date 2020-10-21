using App_Prueba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace App_Prueba.ViewModel
{
    public class ScoreViewModel : BaseViewModel
    {
        private ObservableCollection<Answer> _listaRespuesta = new ObservableCollection<Answer>();

        public ObservableCollection<Answer> ListaRespuesta { get { return _listaRespuesta; } set { SetValue(ref _listaRespuesta, value); } }


        public ScoreViewModel()
        {
            this.ListaRespuesta = ((App)Application.Current).Respuestas;
        }

        public void Cargar()
        {

        }
    }
}
