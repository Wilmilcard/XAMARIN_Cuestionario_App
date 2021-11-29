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
        private string _categoria, _pregunta, _porcentajeBar, _respuestaCorrecta, _respuesta1, _respuesta2, _respuesta3, _respuesta4;
        private ObservableCollection<QuestionChoise> _listaPreguntas = new ObservableCollection<QuestionChoise>();
        public int Dificultad = 1;

        public int PreguntaActual { get { return _preguntaActual; } set { _preguntaActual = value; } }
        public double Porcentaje { get { return _porcentaje; } set { _porcentaje = value; } }
        public string Categoria { get { return _categoria; } set { SetValue(ref _categoria, value); } }
        public string Pregunta { get { return _pregunta; } set { SetValue(ref _pregunta, value); } }
        public string PorcentajeBar { get { return _porcentajeBar; } set { SetValue(ref _porcentajeBar, value); } }
        public string RespuestaCorrecta { get { return _respuestaCorrecta; } set { SetValue(ref _respuestaCorrecta, value); } }
        public string Respuesta1 { get { return _respuesta1; } set { SetValue(ref _respuesta1, value); } }
        public string Respuesta2 { get { return _respuesta2; } set { SetValue(ref _respuesta2, value); } }
        public string Respuesta3 { get { return _respuesta3; } set { SetValue(ref _respuesta3, value); } }
        public string Respuesta4 { get { return _respuesta4; } set { SetValue(ref _respuesta4, value); } }
        public ObservableCollection<QuestionChoise> ListaPreguntas { get { return _listaPreguntas; } set { _listaPreguntas = value; } }
        public ICommand AnswerSelected1Command { get { return new RelayCommand(AnswerSelected1); } }
        public ICommand AnswerSelected2Command { get { return new RelayCommand(AnswerSelected2); } }
        public ICommand AnswerSelected3Command { get { return new RelayCommand(AnswerSelected3); } }
        public ICommand AnswerSelected4Command { get { return new RelayCommand(AnswerSelected4); } }

        public GameChoiseViewModel()
        {
            ((App)Application.Current).Respuestas = new ObservableCollection<Answer>();
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

            //Las respuestas quedan organizadas aleatoriamente ↓↓↓
            lista_respuestas.OrderBy(x => rnd.Next());

            this.Respuesta1 = HttpUtility.HtmlDecode(lista_respuestas[0]);
            this.Respuesta2 = HttpUtility.HtmlDecode(lista_respuestas[1]);
            this.Respuesta3 = HttpUtility.HtmlDecode(lista_respuestas[2]);
            this.Respuesta4 = HttpUtility.HtmlDecode(lista_respuestas[3]);
        }

        public void LoadNextQuestion()
        {
            if (this.PreguntaActual >= 9)
                return;

            var rnd = new Random();
            this.PreguntaActual++;
            this.Categoria = ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].category;
            this.Pregunta = ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].question;
            this.RespuestaCorrecta = ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].correct_answer;

            var lista_respuestas = new List<string>();
            foreach (var i in ((App)Application.Current).ListaPreguntasChoise[this.PreguntaActual].incorrect_answers)
            {
                lista_respuestas.Add(i);
            };
            lista_respuestas.Add(this.RespuestaCorrecta);

            //Las respuestas quedan organizadas aleatoriamente ↓↓↓
            lista_respuestas.OrderBy(x => rnd.Next());

            this.Respuesta1 = HttpUtility.HtmlDecode(lista_respuestas[0]);
            this.Respuesta2 = HttpUtility.HtmlDecode(lista_respuestas[1]);
            this.Respuesta3 = HttpUtility.HtmlDecode(lista_respuestas[2]);
            this.Respuesta4 = HttpUtility.HtmlDecode(lista_respuestas[3]);

            this.Porcentaje += 0.1;
            this.PorcentajeBar = Porcentaje.ToString();
        }

        public void AnswerSelected1()
        {
            ((App)Application.Current).Respuestas.Add(createAnswer(this.Respuesta1));
            this.LoadNextQuestion();
        }

        public void AnswerSelected2()
        {
            ((App)Application.Current).Respuestas.Add(createAnswer(this.Respuesta2));
            this.LoadNextQuestion();
        }

        public void AnswerSelected3()
        {
            ((App)Application.Current).Respuestas.Add(createAnswer(this.Respuesta3));
            this.LoadNextQuestion();
        }

        public void AnswerSelected4()
        {
            ((App)Application.Current).Respuestas.Add(createAnswer(this.Respuesta4));
            this.LoadNextQuestion();
        }

        private Answer createAnswer(string respuestaActual)
        {
            var AnswerUser = new Answer();
            AnswerUser.id_question = this.PreguntaActual;
            AnswerUser.question = this.Pregunta;
            AnswerUser.answerUser = this.ValidateAnswer(respuestaActual);
            AnswerUser.answerCorrect = this.ValidateAnswer(respuestaActual);

            return AnswerUser;
        }

        private bool ValidateAnswer(string answer)
        {
            if (answer == this.RespuestaCorrecta)
                return true;
            
            return false;
        }
    }
}
