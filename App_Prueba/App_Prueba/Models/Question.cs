using System;
using System.Collections.Generic;
using System.Text;

namespace App_Prueba.Models
{
    public class Question
    {
        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public bool correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }
    }
}
