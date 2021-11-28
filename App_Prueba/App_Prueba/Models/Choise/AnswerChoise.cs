using System;
using System.Collections.Generic;
using System.Text;

namespace App_Prueba.Models
{
    public class AnswerChoise
    {
        public int id_question { get; set; }
        public string question { get; set; }
        public string answerUser { get; set; }
        public string answerCorrect { get; set; }
    }
}
