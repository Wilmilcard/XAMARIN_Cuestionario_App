using App_Prueba.Clases;
using App_Prueba.Models;
using App_Prueba.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Prueba.ViewModel
{
    public class GameChoiseViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        private int _preguntaActual = 0;
        private double _porcentaje = 0.1;
        private string _categoria, _pregunta, _porcentajeBar, _respuestaCorrecta, respuesta1, respuesta2, respuesta3, respuesta4;
        private ObservableCollection<QuestionChoise> _listaPreguntas = new ObservableCollection<QuestionChoise>();
        public int Dificultad = 1;

        public int PreguntaActual { get { return _preguntaActual; } set { _preguntaActual = value; } }
        public double Porcentaje { get { return _porcentaje; } set { _porcentaje = value; } }
        public string Categoria { get { return _categoria; } set { SetValue(ref _categoria, value); } }
        public string Pregunta { get { return _pregunta; } set { SetValue(ref _pregunta, value); } }
        public string PorcentajeBar { get { return _porcentajeBar; } set { SetValue(ref _porcentajeBar, value); } }
        public string RespuestaCorrecta { get { return _respuestaCorrecta; } set { SetValue(ref _respuestaCorrecta, value); } }
        public string Respuesta1 { get { return respuesta1; } set { SetValue(ref respuesta1, value); } }
        public string Respuesta2 { get { return respuesta2; } set { SetValue(ref respuesta2, value); } }
        public string Respuesta3 { get { return respuesta3; } set { SetValue(ref respuesta3, value); } }
        public string Respuesta4 { get { return respuesta4; } set { SetValue(ref respuesta4, value); } }
        public ObservableCollection<QuestionChoise> ListaPreguntas { get { return _listaPreguntas; } set { _listaPreguntas = value; } }
        public ICommand Answer1Command { get { return new RelayCommand(Answer1); } }
        public ICommand Answer2Command { get { return new RelayCommand(Answer2); } }
        public ICommand Answer3Command { get { return new RelayCommand(Answer3); } }
        public ICommand Answer4Command { get { return new RelayCommand(Answer4); } }

        public GameChoiseViewModel()
        {
            ((App)Application.Current).RespuestasChoise = new ObservableCollection<AnswerChoise>();
            this.PorcentajeBar = "0.1";
            this.GetFirst();
        }

        public async void GetFirst()
        {
            var rnd = new Random();
            this.Categoria = ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].category;
            this.Pregunta = ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].question;
            this.RespuestaCorrecta = ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].correct_answer;

            var lista_respuestas = new List<string>();
            foreach(var i in ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].incorrect_answers)
            {
                lista_respuestas.Add(i);
            };
            lista_respuestas.Add(this.RespuestaCorrecta);
            lista_respuestas.OrderBy(x => rnd.Next());

            this.respuesta1 = HttpUtility.HtmlDecode(lista_respuestas[0]);
            this.respuesta2 = HttpUtility.HtmlDecode(lista_respuestas[1]);
            this.respuesta3 = HttpUtility.HtmlDecode(lista_respuestas[2]);
            this.respuesta4 = HttpUtility.HtmlDecode(lista_respuestas[3]);
        }

        public void Answer1()
        {

        }

        public void Answer2()
        {

        }

        public void Answer3()
        {

        }

        public void Answer4()
        {

        }
    }
}
