using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmProject.Models
{
    public class Film
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public int CinemaRoomID { get; set; }
        public CinemaRoom CinemaRoom { get; set; }

    }
}