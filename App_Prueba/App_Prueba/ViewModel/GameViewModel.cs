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
        private string _categoria, _pregunta, _porcentajeBar, _sourceImage;
        private bool _respuestaCorrecta;
        private ObservableCollection<Question> _listaPreguntas = new ObservableCollection<Question>();
        public int Dificultad = 1;

        public int PreguntaActual { get { return _preguntaActual; } set { _preguntaActual = value; } }
        public double Porcentaje { get { return _porcentaje; } set { _porcentaje = value; } }
        public string Categoria { get { return _categoria; } set { SetValue(ref _categoria, value); } }
        public string Pregunta { get { return _pregunta; } set { SetValue(ref _pregunta, value); } }
        public string PorcentajeBar { get { return _porcentajeBar; } set { SetValue(ref _porcentajeBar, value); } }
        public string SourceImage { get { return _sourceImage; } set { SetValue(ref _sourceImage, value); } }
        public bool RespuestaCorrecta { get { return _respuestaCorrecta; } set { SetValue(ref _respuestaCorrecta, value); } }
        public ObservableCollection<Question> ListaPreguntas { get { return _listaPreguntas; } set { _listaPreguntas = value; } }
        public ICommand AnswerTCommand { get { return new RelayCommand(RespVerdadera); } }
        public ICommand AnswerFCommand { get { return new RelayCommand(RespFalsa); } }


        public GameViewModel()
        {
            ((App)Application.Current).Respuestas = new ObservableCollection<Answer>();
            this.PorcentajeBar = "0.1";
            this.GetFirst();
        }

        public async void GetFirst()
        {
            this.Categoria = ((App)Application.Current).ListaPreguntas[this.PreguntaActual].category;
            this.Pregunta = ((App)Application.Current).ListaPreguntas[this.PreguntaActual].question;
            this.RespuestaCorrecta = ((App)Application.Current).ListaPreguntas[this.PreguntaActual].correct_answer;

            this.SourceImage = "gato2.gif";
        }

        public void LoadNextQuestion()
        {
            if (this.PreguntaActual >= 9)
                return;

            this.PreguntaActual++;
            this.Categoria = ((App)Application.Current).ListaPreguntas[this.PreguntaActual].category;
            this.Pregunta = ((App)Application.Current).ListaPreguntas[this.PreguntaActual].question;
            this.RespuestaCorrecta = ((App)Application.Current).ListaPreguntas[this.PreguntaActual].correct_answer;

            this.Porcentaje += 0.1;
            this.PorcentajeBar = Porcentaje.ToString();
        }

        public void RespVerdadera()
        {
            ((App)Application.Current).Respuestas.Add(new Answer() 
            { 
                id_question = this.PreguntaActual, 
                question = this.Pregunta, 
                answerUser = true, 
                answerCorrect = this.RespuestaCorrecta
            });
            this.LoadNextQuestion();
        }

        public async void RespFalsa()
        {
            ((App)Application.Current).Respuestas.Add(new Answer() 
            { 
                id_question = this.PreguntaActual, 
                question = this.Pregunta, 
                answerUser = false, 
                answerCorrect = this.RespuestaCorrecta
            });
            this.LoadNextQuestion();
        }

    }
}
