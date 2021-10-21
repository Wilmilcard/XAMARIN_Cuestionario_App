﻿using App_Prueba.Clases;
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
        private ObservableCollection<Question> _listaPreguntas = new ObservableCollection<Question>();
        private string _stats;

        public ObservableCollection<Question> ListaPreguntas { get { return _listaPreguntas; } set { _listaPreguntas = value; } }
        public List<Categories> Categories = new List<Categories>();
        public ICommand EasyCommand { get { return new RelayCommand(easy); } }
        public ICommand MediumCommand { get { return new RelayCommand(medium); } }
        public ICommand HardCommand { get { return new RelayCommand(hard); } }

        public string Stats { get { return _stats; } set { SetValue(ref _stats, value); } }

        public PrincipalViewModel()
        {
            this.GetStats();
            this.GetAll();
        }

        public async void GetStats()
        {
            var rest = new RestClient();
            var rpta = await rest.Get<Stats>("https://opentdb.com/api_count_global.php");

            this.Stats = rpta.overall.total_num_of_verified_questions.ToString();
        }

        public async void GetAll()
        {
            var Preguntas = new Result();
            var Categories = new Categories();
            var rest = new RestClient();

            var rpta = await rest.Get<Result>();
            if (rpta != null)
                Preguntas = rpta;

            var cat = await rest.Get<Categories>("https://opentdb.com/api_category.php");
            if (cat != null)
                Categories = cat;

            foreach (var pregunta in Preguntas.results)
            {
                this.ListaPreguntas.Add(new Question()
                {
                    categoryId = Categories.trivia_categories.Where(x => x.name == pregunta.category).FirstOrDefault().id,
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
