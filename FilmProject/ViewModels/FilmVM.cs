using FilmProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmProject.ViewModels
{
    public class FilmVM
    {
        public List<Film> Films { get; set; }
        public Film Film { get; set; }
    }

}