using System;
using System.Collections.Generic;
using System.Text;

namespace App_Prueba.Models
{
    public class Stats
    {
        public Overall overall { get; set; }
    }

    public class Overall
    {
        public int total_num_of_questions { get; set; }
        public int total_num_of_pending_questions { get; set; }
        public int total_num_of_verified_questions { get; set; }
        public int total_num_of_rejected_questions { get; set; }
    }
}
