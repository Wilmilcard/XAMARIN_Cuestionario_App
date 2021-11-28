using System;
using System.Collections.Generic;
using System.Text;

namespace App_Prueba.Models
{
    public class ResultBool
    {
        public int response_code { get; set; }
        public List<QuestionBool> results { get; set; }
    }
}
