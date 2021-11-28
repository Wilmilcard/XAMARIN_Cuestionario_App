using System;
using System.Collections.Generic;
using System.Text;

namespace App_Prueba.Models
{
    public class QuestionChoise
    {
        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }
    }
}
