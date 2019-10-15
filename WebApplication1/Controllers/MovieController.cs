using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Web.Mvc;
using System.Data.Entity;



namespace WebApplication1.Controllers
{
    [Authorize]

    public class MovieController : Controller
    {
        // GET: Movie
        private ApplicationDbContext dbContext = null;
        public MovieController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            var movies = dbContext.Movies.Include(k => k.Genres).ToList();
            return View("movieview", movies);

        }
        public ActionResult Details(int id)
        {
            var movie = dbContext.Movies.Include(l => l.Genres).ToList().SingleOrDefault(a => a.id == id);
            return View("Details", movie);
        }
        public IEnumerable<SelectListItem> TheatreList()
        {
            var Theatres = new List<SelectListItem>
            {
                new SelectListItem{Text="Select a Theatre",Value="0",Disabled=true,Selected=true},
                new SelectListItem{Text="AGS" ,Value="1"},
                new SelectListItem{Text="luxe",Value="2"},
                new SelectListItem{Text="PVR",Value="3"}
            };
            return Theatres;

        }
        [HttpGet]
        public ActionResult Create1()
        {
            var Movies = new movie();


            ViewBag.Genres = ListGenre();
            ViewBag.theatre = TheatreList();



            return View(Movies);
        }
        [HttpGet]
        public ActionResult EditMovie(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(c => c.id == id);
            if (movie != null)
            {
                ViewBag.Genres = ListGenre();
                ViewBag.theatre = TheatreList();
                return View(movie);
            }
            return HttpNotFound("movie not found");
        }
      
       
        [HttpPost]

        public ActionResult Create1(movie MovieFromView)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = ListGenre();
                ViewBag.theatre = TheatreList();
                return View(MovieFromView);
            }
            dbContext.Movies.Add(MovieFromView);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }


        public IEnumerable<SelectListItem> ListGenre()
        {
            var Genre = new List<SelectListItem>
            {
                new SelectListItem{Text="Select a Genre",Value="0",Disabled=true,Selected=true},
                new SelectListItem{Text="ROMCOM",Value="1"},
                new SelectListItem{Text="Comedy",Value="2"},
                new SelectListItem{Text="Horror",Value="3"}
            };
            return Genre;

        }
       
        //  public ActionResult MovieSearch(string MovieName)
        //  {
        //      movie mantra = new movie();
        //      var ListOfMovies = MovieDetails();
        //      foreach(var c in ListOfMovies)
        //      {
        //          if(MovieName==c.MovieName)
        //          {
        //              mantra = c;
        //          }
        //      }
        //    return View(mantra);
        //}
    }
}