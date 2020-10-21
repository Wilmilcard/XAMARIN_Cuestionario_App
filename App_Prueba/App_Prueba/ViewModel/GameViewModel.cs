using App_Prueba.Clases;
using App_Prueba.Models;
using App_Prueba.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Prueba.ViewModel
{
    public class GameViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        private int _preguntaActual = 0;
        private string _categoria, _pregunta, _posicion;
        private ObservableCollection<Question> _listaPreguntas = new ObservableCollection<Question>();
        private ObservableCollection<Answer> _listaRespuestas = new ObservableCollection<Answer>();

        public int PreguntaActual{ get { return _preguntaActual; } set { _preguntaActual = value; } }
        public string Categoria { get { return _categoria; } set { SetValue(ref _categoria, value); } }
        public string Pregunta { get { return _pregunta; } set { SetValue(ref _pregunta, value); } }
        public string Posicion { get { return _posicion; } set { SetValue(ref _posicion, value); } }
        public ObservableCollection<Question> ListaPreguntas { get { return _listaPreguntas; } set { _listaPreguntas = value; } }
        public ObservableCollection<Answer> ListaRespuestas { get { return _listaRespuestas; } set { _listaRespuestas = value; } }
        public ICommand AnswerTCommand { get { return new RelayCommand(RespVerdadera); } }
        public ICommand AnswerFCommand { get { return new RelayCommand(RespFalsa); } }


        public GameViewModel()
        {
            this.GetAll();
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
                    question = pregunta.question.Replace("&quot;", "'"),
                    correct_answer = pregunta.correct_answer,
                    incorrect_answers = pregunta.incorrect_answers
                });
            }

            this.Categoria = this.ListaPreguntas[this.PreguntaActual].category;
            this.Pregunta = this.ListaPreguntas[this.PreguntaActual].question;
            this.Posicion = $"{this.PreguntaActual + 1} / 10";

        }

        public void LoadNextQuestion()
        {
            if (this.PreguntaActual >= 10)
                return;

            this.PreguntaActual++;
            this.Categoria = this.ListaPreguntas[this.PreguntaActual].category;
            this.Pregunta = this.ListaPreguntas[this.PreguntaActual].question;
            this.Posicion = $"{this.PreguntaActual + 1} / 10";
        }

        public void RespVerdadera()
        {
            this.ListaRespuestas.Add(new Answer() { id_question = this.PreguntaActual, answer = "True" });
            //Application.Current.MainPage.DisplayAlert("Error", "msj", "OK");
            this.LoadNextQuestion();
        }
        public async void RespFalsa()
        {
            this.ListaRespuestas.Add(new Answer() { id_question = this.PreguntaActual, answer = "False" });
            this.LoadNextQuestion();
        }

    }
}
