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
    public class GameViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        private int _preguntaActual = 0;
        private double _porcentaje = 0.1;
        private string _categoria, _pregunta, _posicion, _respuestaCorrecta, _porcentajeBar;
        private ObservableCollection<Question> _listaPreguntas = new ObservableCollection<Question>();
        public int Dificultad = 1;

        public int PreguntaActual { get { return _preguntaActual; } set { _preguntaActual = value; } }
        public double Porcentaje { get { return _porcentaje; } set { _porcentaje = value; } }
        public string Categoria { get { return _categoria; } set { SetValue(ref _categoria, value); } }
        public string Pregunta { get { return _pregunta; } set { SetValue(ref _pregunta, value); } }
        public string Posicion { get { return _posicion; } set { SetValue(ref _posicion, value); } }
        public string PorcentajeBar { get { return _porcentajeBar; } set { SetValue(ref _porcentajeBar, value); } }
        public string RespuestaCorrecta { get { return _respuestaCorrecta; } set { SetValue(ref _respuestaCorrecta, value); } }
        public ObservableCollection<Question> ListaPreguntas { get { return _listaPreguntas; } set { _listaPreguntas = value; } }
        public ICommand AnswerTCommand { get { return new RelayCommand(RespVerdadera); } }
        public ICommand AnswerFCommand { get { return new RelayCommand(RespFalsa); } }

        Timer t = new Timer(500);

        public GameViewModel()
        {
            ((App)Application.Current).Respuestas = new ObservableCollection<Answer>();
            this.PorcentajeBar = "0.1";

            t.Elapsed += EventoElapsed;
            t.Start();
        }

        public async void GetAll()
        {
            Result Preguntas = new Result();
            RestClient rest = new RestClient();

            var rpta = await rest.Get<Result>();
            if (rpta != null)
                Preguntas = rpta;

            foreach (var pregunta in Preguntas.results)
            {
                this.ListaPreguntas.Add(new Question()
                {
                    category = pregunta.category,
                    type = pregunta.type,
                    difficulty = pregunta.difficulty,
                    question = pregunta.question.Replace("&quot;", "'").Replace("&#039;", "'").Replace("&rdquo;", "!").Replace(";H&ocirc;", "ô").Replace(" &Idquo;", ": ").Replace("&epsilon;", "ε"),
                    correct_answer = pregunta.correct_answer,
                    incorrect_answers = pregunta.incorrect_answers
                });
            }

            this.Categoria = this.ListaPreguntas[this.PreguntaActual].category;
            this.Pregunta = this.ListaPreguntas[this.PreguntaActual].question;
            this.RespuestaCorrecta = this.ListaPreguntas[this.PreguntaActual].correct_answer;
            this.Posicion = $"{this.PreguntaActual + 1} / 10";

        }

        public void LoadNextQuestion()
        {
            if (this.PreguntaActual >= 9)
                return;

            this.PreguntaActual++;
            this.Categoria = this.ListaPreguntas[this.PreguntaActual].category;
            this.Pregunta = this.ListaPreguntas[this.PreguntaActual].question;
            this.RespuestaCorrecta = this.ListaPreguntas[this.PreguntaActual].correct_answer;
            this.Posicion = $"{this.PreguntaActual + 1} / 10";

            this.Porcentaje += 0.1;
            this.PorcentajeBar = Porcentaje.ToString();
        }

        public void EventoElapsed(object sender, ElapsedEventArgs e)
        {
            this.GetAll();
            t.Stop();
        }

        public void RespVerdadera()
        {
            ((App)Application.Current).Respuestas.Add(new Answer() { id_question = this.PreguntaActual, question = this.Pregunta, answerUser = "+", answerCorrect = this.RespuestaCorrecta == "True" ? "+" : "-" });
            this.LoadNextQuestion();
        }
        public async void RespFalsa()
        {
            ((App)Application.Current).Respuestas.Add(new Answer() { id_question = this.PreguntaActual, question = this.Pregunta, answerUser = "-", answerCorrect = this.RespuestaCorrecta == "True" ? "+" : "-" });
            this.LoadNextQuestion();
        }

    }
}
