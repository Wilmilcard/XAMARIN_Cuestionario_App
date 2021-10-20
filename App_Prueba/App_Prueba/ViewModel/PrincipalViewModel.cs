using App_Prueba.Clases;
using App_Prueba.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Prueba.ViewModel
{
    public class PrincipalViewModel : BaseViewModel
    {
        private ObservableCollection<Question> _listaPreguntas = new ObservableCollection<Question>();

        public ObservableCollection<Question> ListaPreguntas { get { return _listaPreguntas; } set { _listaPreguntas = value; } }
        public ICommand EasyCommand { get { return new RelayCommand(easy); } }
        public ICommand MediumCommand { get { return new RelayCommand(medium); } }
        public ICommand HardCommand { get { return new RelayCommand(hard); } }

        public PrincipalViewModel()
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
                    question = HttpUtility.HtmlDecode(pregunta.question),
                    correct_answer = pregunta.correct_answer,
                    incorrect_answers = pregunta.incorrect_answers
                });
            }

            ((App)Application.Current).ListaPreguntas = this.ListaPreguntas;
        }

        public void easy()
        {
            ((App)Application.Current).Dificultad = 0;
            this.GetAll();
        }

        public void medium()
        {
            ((App)Application.Current).Dificultad = 1;
            this.GetAll();
        }

        public void hard()
        {
            ((App)Application.Current).Dificultad = 2;
            this.GetAll();
        }
    }
}
