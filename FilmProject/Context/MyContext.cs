using FilmProject.Models;
using System.Data.Entity;

namespace FilmProject.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnection")
        {

        }


        public DbSet<Film> Films { get; set; }
        public DbSet<CinemaRoom> CinemaRooms { get; set; }

    }
}