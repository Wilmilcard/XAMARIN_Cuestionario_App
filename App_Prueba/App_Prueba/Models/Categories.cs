using System;
using System.Collections.Generic;
using System.Text;

namespace App_Prueba.Models
{
    public class Categories
    {
        public List<Category> trivia_categories { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
