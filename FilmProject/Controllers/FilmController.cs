using FilmProject.Context;
using FilmProject.DesignPatterns.SingletonPattern;
using FilmProject.Models;
using FilmProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FilmProject.Controllers
{
    public class FilmController : Controller
    {
        MyContext _db;
        public FilmController()
        {
            _db = DBTool.DBInstance;
        }
        public ActionResult IndexPage()
        {
            FilmVM fvm = new FilmVM
            {
                Films = _db.Films.Include("CinemaRoom").ToList()
            };

            return View(fvm);
        }
        public ActionResult CreatePage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePage(Film film)
        {
            _db.Films.Add(film);
            _db.SaveChanges();
            return RedirectToAction("IndexPage");
        }
        public ActionResult DeletePage(int id)
        {
            _db.Films.Remove(_db.Films.Find(id));
            _db.SaveChanges();
            return RedirectToAction("IndexPage");
        }
        public ActionResult EditPage(int id)
        {
            FilmVM fvm = new FilmVM
            {
                Film = _db.Films.Find(id)
            };
            return View(fvm);
        }
        [HttpPost]
        public ActionResult EditPage(Film film)
        {
            Film update = _db.Films.Find(film.ID);
            update.Name = film.Name;
            update.Genre = film.Genre;
            update.Director = film.Director;
            update.Year = film.Year;
            _db.SaveChanges();

            return RedirectToAction("IndexPage");
        }
        public ActionResult FilterPage()
        {
            int minYear = Request.QueryString["minYear"] == "" || Request.QueryString["minYear"] == null ? 0 : Convert.ToInt32(Request.QueryString["minYear"]);
            int maxYear = Request.QueryString["maxYear"] == "" || Request.QueryString["maxYear"] == null ? 0 : Convert.ToInt32(Request.QueryString["maxYear"]);
            string directorType = Request.QueryString["directorType"];
            string movieType = Request.QueryString["movieType"];
            int cinemaRooms = Request.QueryString["cinemaType"] == "" || Request.QueryString["cinemaType"] == null ? 0 : Convert.ToInt32(Request.QueryString["cinemaType"]);

            List<Film> filter = null;


            if (minYear != 0 && maxYear == 0 && string.IsNullOrEmpty(directorType) && string.IsNullOrEmpty(movieType) && cinemaRooms == 0)
            {
                filter = _db.Films.Where(w => w.Year == minYear).ToList();

            }
            if (minYear != 0 && maxYear != 0 && string.IsNullOrEmpty(directorType) && string.IsNullOrEmpty(movieType) && cinemaRooms == 0)
            {
                filter = _db.Films.Where(w => w.Year >= minYear && w.Year <= maxYear).ToList();
            }
            if (minYear != 0 && maxYear != 0 && !string.IsNullOrEmpty(directorType) && string.IsNullOrEmpty(movieType) && cinemaRooms == 0)
            {
                filter = _db.Films.Where(w => w.Director == directorType && w.Year >= minYear && w.Year <= maxYear).ToList();
            }
            if ((minYear == 0 && maxYear == 0) || !string.IsNullOrEmpty(movieType) || !string.IsNullOrEmpty(directorType) || cinemaRooms != 0)
            {
                filter = _db.Films.Where(w => w.Genre == movieType || w.Director == directorType || w.CinemaRoom.ID == cinemaRooms).ToList();
            }

            FilmVM fvm = new FilmVM
            {
                Films = filter
            };

            return View(fvm);
        }

    }
}