using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmProject.Models
{
    public class CinemaRoom
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public List<Film> Films { get; set; }
    }
}