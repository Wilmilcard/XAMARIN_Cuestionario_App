using App_Prueba.Clases;
using App_Prueba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace App_Prueba.ViewModel
{
    public class GameViewModel : BaseViewModel
    {
        private int _preguntaActual = 0;
        private string _categoria;
        private ObservableCollection<Question> _listaPreguntas = new ObservableCollection<Question>();

        public int PreguntaActual{ get { return _preguntaActual; } set { _preguntaActual = value; } }
        public string Categoria { get { return _categoria; } set { _categoria = value; OnPropertyChanged("Categoria"); } }
        public ObservableCollection<Question> ListaPreguntas { get { return _listaPreguntas; } set { _listaPreguntas = value; } }


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
                    question = pregunta.question,
                    correct_answer = pregunta.correct_answer,
                    incorrect_answers = pregunta.incorrect_answers
                });
            }
            this.Categoria = this.ListaPreguntas[this.PreguntaActual].category;
        }

        public void LoadNextQuestion()
        {
        }

    }
}
