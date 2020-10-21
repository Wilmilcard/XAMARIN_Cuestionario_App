using App_Prueba.Clases;
using App_Prueba.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Prueba.ViewModel
{
    public class GameViewModel : BaseViewModel
    {
        private string titulo;
        public string Titulo { get { return titulo; } set { titulo = value; } }


        public GameViewModel()
        {
            this.GetAll();
        }

        public async void GetAll()
        {
            RestClient rest = new RestClient();
            var rpta = await rest.Get<Result>();
            if (rpta != null)
                this.Titulo = rpta.results[2].category;
        }
    }
}
