using App_Prueba.Clases;
using App_Prueba.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Prueba.ViewModel
{
    public class PrincipalViewModel : BaseViewModel
    {
        private ObservableCollection<QuestionBool> _listaPreguntasBool = new ObservableCollection<QuestionBool>();
        private ObservableCollection<QuestionChoise> _listaPreguntasChoise = new ObservableCollection<QuestionChoise>();
        private string _stats;

        public ObservableCollection<QuestionBool> ListaPreguntasBool { get { return _listaPreguntasBool; } set { _listaPreguntasBool = value; } }
        public ObservableCollection<QuestionChoise> ListaPreguntasChoise { get { return _listaPreguntasChoise; } set { _listaPreguntasChoise = value; } }
        public ICommand EasyCommand { get { return new RelayCommand(easy); } }
        public ICommand MediumCommand { get { return new RelayCommand(medium); } }
        public ICommand HardCommand { get { return new RelayCommand(hard); } }
        public ICommand BoolCommand { get { return new RelayCommand(boolean); } }
        public ICommand MultipleChoiseCommand { get { return new RelayCommand(multipleChoise); } }

        public string Stats { get { return _stats; } set { SetValue(ref _stats, value); } }

        public PrincipalViewModel()
        {
            this.GetAll();
            this.GetStats();
        }

        public async void GetStats()
        {
            var rest = new RestClient();
            var rpta = await rest.Get<Stats>("https://opentdb.com/api_count_global.php");
            this.Stats = "";

            this.Stats = rpta.overall.total_num_of_verified_questions.ToString();
        }

        public async void GetAll()
        {
            var PreguntasBool = new ResultBool();
            var PreguntasChoise = new ResultChoise();
            var rest = new RestClient();
            var rptaBool = new ResultBool();
            var rptaChoise = new ResultChoise();
            ((App)Application.Current).ListaPreguntasBool = new ObservableCollection<QuestionBool>();
            ((App)Application.Current).ListaPreguntasChoise = new ObservableCollection<QuestionChoise>();
            this.ListaPreguntasBool = new ObservableCollection<QuestionBool>();
            this.ListaPreguntasChoise = new ObservableCollection<QuestionChoise>();

            //Consulta por modo de juego
            if (((App)Application.Current).ModeGame == 0)
            {
                rptaBool = await rest.Get<ResultBool>();
                
                if (rptaBool != null)
                    PreguntasBool = rptaBool;

                foreach (var pregunta in PreguntasBool.results)
                {
                    this.ListaPreguntasBool.Add(new QuestionBool()
                    {
                        category = pregunta.category,
                        type = pregunta.type,
                        difficulty = pregunta.difficulty,
                        question = HttpUtility.HtmlDecode(pregunta.question),
                        correct_answer = pregunta.correct_answer,
                        incorrect_answers = pregunta.incorrect_answers
                    });
                }

                ((App)Application.Current).ListaPreguntasBool = this.ListaPreguntasBool;
            }
            else
            {
                rptaChoise = await rest.Get<ResultChoise>();

                if (rptaChoise != null)
                    PreguntasChoise = rptaChoise;

                foreach (var pregunta in PreguntasChoise.results)
                {
                    this.ListaPreguntasChoise.Add(new QuestionChoise()
                    {
                        category = pregunta.category,
                        type = pregunta.type,
                        difficulty = pregunta.difficulty,
                        question = HttpUtility.HtmlDecode(pregunta.question),
                        correct_answer = HttpUtility.HtmlDecode(pregunta.correct_answer),
                        incorrect_answers = pregunta.incorrect_answers
                    });
                }

                ((App)Application.Current).ListaPreguntasChoise = this.ListaPreguntasChoise;
            }

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

        public void boolean()
        {
            ((App)Application.Current).ModeGame = 0;
            this.GetAll();
        }

        public void multipleChoise()
        {
            ((App)Application.Current).ModeGame = 1;
            this.GetAll();
        }
    }
}
