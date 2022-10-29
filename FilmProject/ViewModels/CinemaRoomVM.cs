using FilmProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmProject.ViewModels
{
    public class CinemaRoomVM
    {
        public List<CinemaRoom> CinemaRooms { get; set; }
        public CinemaRoom CinemaRoom { get; set; }
    }
}