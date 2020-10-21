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
        private int _respuestasCorrectas = 0;
        private ObservableCollection<Answer> _listaRespuesta = new ObservableCollection<Answer>();

        public int RespuestasCorrectas { get { return _respuestasCorrectas; } set { SetValue(ref _respuestasCorrectas, value); } }
        public ObservableCollection<Answer> ListaRespuesta { get { return _listaRespuesta; } set { SetValue(ref _listaRespuesta, value); } }


        public ScoreViewModel()
        {
            this.ListaRespuesta = ((App)Application.Current).Respuestas;
            this.ResultadoFinal();
        }

        public void ResultadoFinal()
        {
            foreach(var rpta in ((App)Application.Current).Respuestas)
            {
                if (rpta.answerUser == rpta.answerCorrect)
                    this.RespuestasCorrectas++;
            }
        }
    }
}
