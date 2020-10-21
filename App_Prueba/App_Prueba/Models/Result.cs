using System;
using System.Collections.Generic;
using System.Text;

namespace App_Prueba.Models
{
    public class Result
    {
        public int response_code { get; set; }
        public List<Question> results { get; set; }
    }
}
