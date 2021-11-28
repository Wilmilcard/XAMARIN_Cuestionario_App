using App_Prueba.Clases;
using App_Prueba.Models;
using App_Prueba.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Prueba.ViewModel
{
    public class GameChoiseViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        private int _preguntaActual = 0;
        private double _porcentaje = 0.1;
        private string _categoria, _pregunta, _porcentajeBar, _respuestaCorrecta, respuestaIncorrecta1, respuestaIncorrecta2, respuestaIncorrecta3;
        private ObservableCollection<QuestionChoise> _listaPreguntas = new ObservableCollection<QuestionChoise>();
        public int Dificultad = 1;

        public int PreguntaActual { get { return _preguntaActual; } set { _preguntaActual = value; } }
        public double Porcentaje { get { return _porcentaje; } set { _porcentaje = value; } }
        public string Categoria { get { return _categoria; } set { SetValue(ref _categoria, value); } }
        public string Pregunta { get { return _pregunta; } set { SetValue(ref _pregunta, value); } }
        public string PorcentajeBar { get { return _porcentajeBar; } set { SetValue(ref _porcentajeBar, value); } }
        public string RespuestaCorrecta { get { return _respuestaCorrecta; } set { SetValue(ref _respuestaCorrecta, value); } }
        public string RespuestaIncorrecta1 { get { return respuestaIncorrecta1; } set { SetValue(ref respuestaIncorrecta1, value); } }
        public string RespuestaIncorrecta2 { get { return respuestaIncorrecta2; } set { SetValue(ref respuestaIncorrecta2, value); } }
        public string RespuestaIncorrecta3 { get { return respuestaIncorrecta3; } set { SetValue(ref respuestaIncorrecta3, value); } }
        public ObservableCollection<QuestionChoise> ListaPreguntas { get { return _listaPreguntas; } set { _listaPreguntas = value; } }
        public ICommand Answer1Command { get { return new RelayCommand(Respuesta1); } }
        public ICommand Answer2Command { get { return new RelayCommand(Respuesta2); } }
        public ICommand Answer3Command { get { return new RelayCommand(Respuesta3); } }
        public ICommand Answer4Command { get { return new RelayCommand(Respuesta4); } }

        public GameChoiseViewModel()
        {
            ((App)Application.Current).RespuestasChoise = new ObservableCollection<AnswerChoise>();
            this.PorcentajeBar = "0.1";
            this.GetFirst();
        }

        public async void GetFirst()
        {
            this.Categoria = ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].category;
            this.Pregunta = ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].question;
            this.RespuestaCorrecta = ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].correct_answer;
            this.RespuestaIncorrecta1 = ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].incorrect_answers[0];
            this.RespuestaIncorrecta2 = ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].incorrect_answers[1];
            this.RespuestaIncorrecta3 = ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].incorrect_answers[2];
        }

        public void Respuesta1()
        {

        }

        public void Respuesta2()
        {

        }

        public void Respuesta3()
        {

        }

        public void Respuesta4()
        {

        }
    }
}
