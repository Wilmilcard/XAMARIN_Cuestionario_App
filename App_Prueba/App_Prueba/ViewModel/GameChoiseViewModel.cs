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
        private string _categoria, _pregunta, _porcentajeBar, _respuestaCorrecta;
        private ObservableCollection<QuestionBool> _listaPreguntas = new ObservableCollection<QuestionBool>();
        public int Dificultad = 1;

        public int PreguntaActual { get { return _preguntaActual; } set { _preguntaActual = value; } }
        public double Porcentaje { get { return _porcentaje; } set { _porcentaje = value; } }
        public string Categoria { get { return _categoria; } set { SetValue(ref _categoria, value); } }
        public string Pregunta { get { return _pregunta; } set { SetValue(ref _pregunta, value); } }
        public string PorcentajeBar { get { return _porcentajeBar; } set { SetValue(ref _porcentajeBar, value); } }
        public string RespuestaCorrecta { get { return _respuestaCorrecta; } set { SetValue(ref _respuestaCorrecta, value); } }
        public ObservableCollection<QuestionBool> ListaPreguntas { get { return _listaPreguntas; } set { _listaPreguntas = value; } }
        public ICommand Answer1Command { get { return new RelayCommand(Respuesta1); } }
        public ICommand Answer2Command { get { return new RelayCommand(Respuesta2); } }
        public ICommand Answer3Command { get { return new RelayCommand(Respuesta3); } }
        public ICommand Answer4Command { get { return new RelayCommand(Respuesta4); } }

        public GameChoiseViewModel()
        {
            ((App)Application.Current).RespuestasBool = new ObservableCollection<AnswerBool>();
            this.PorcentajeBar = "0.1";
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
