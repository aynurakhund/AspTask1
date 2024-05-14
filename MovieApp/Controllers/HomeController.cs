using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Context;
using MovieApp.DTO;
using MovieApp.Entities;
using MovieApp.Models;
using System.Diagnostics;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<MovieModel> movies = new List<MovieModel>();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            FillMovies();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void FillMovies()
        {
            using (MovieContext mvcontext = new())
            {

                var data = mvcontext.Movies.Select(x => new
                {
                    movieId = x.Id,
                    movieName = x.MovieName,
                    movieimage = x.imageUrl,
                    imdbPoint = x.Imdbs.ImdbPoint,
                    directorId=x.DirectorId,
                    imdbId=x.ImdbId,
                    directorName = x.Directorss.FirstName + " " + x.Directorss.LastName
                }).ToList();

                foreach (var mv in data)
                {
                    MovieModel movie = new MovieModel()
                    {
                        MovieId = mv.movieId,
                        MovieName = mv.movieName,
                        ImgUrl = mv.movieimage,
                        ImdbPoint = mv.imdbPoint,
                        DirectorId=mv.directorId,
                        ImdbId=mv.imdbId,
                        Director = mv.directorName
                    };

                    movies.Add(movie);
                }



            }
        }
       public IActionResult DashboardPage(string SearchString)
        {
            

           
            if (!string.IsNullOrEmpty(SearchString))
            {
                var searchedMovie = new List<MovieModel>();
                foreach (var item in movies)
                {
                    if (item.MovieName.ToLower().Contains(SearchString.ToLower()))
                    {
                        searchedMovie.Add(item);
                    }
                }
                return View(searchedMovie);
            }
            return View(movies);
        }

        public IActionResult GetMovies()
        {
           
            return View(movies);
        } 

        public IActionResult AddMovie()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return View(movieDto);
            }
            using (MovieContext context = new())
            {
                Movie movie = new Movie()
                {
                    MovieName = movieDto.movieName,
                    imageUrl = movieDto.imgUrl,
                    DirectorId = Convert.ToInt32(movieDto.DirectorId),
                    ImdbId = Convert.ToInt32(movieDto.ImdbId)
                };

                context.Movies.Add(movie);
                context.SaveChanges();

                return RedirectToAction("GetMovies", "Home");
            }
            
        }

        public IActionResult EditMovie(int id)
        {
            var editMovie=new MovieModel();
            foreach(var item in movies)
            {
                if (item.MovieId == id)
                {
                    editMovie=item;
                }
            }

            var movieDto = new MovieDto()
            {
                movieName = editMovie.MovieName,
                imgUrl = editMovie.ImgUrl,
                DirectorId = editMovie.DirectorId.ToString(),
                ImdbId = editMovie.ImdbId.ToString()
            };

            ViewData["movieId"] = editMovie.MovieId;
            return View(movieDto);
        }

        [HttpPost]
        public IActionResult EditMovie(int id,MovieDto movieDto)
        {
                     
            using(MovieContext mvcontext = new())
            {
               

                var data = mvcontext.Movies.FirstOrDefault(x => x.Id == id);
                if (data == null)
                {
                    return RedirectToAction("GetMovies", "home");
                }

                if (!ModelState.IsValid)
                {
                    ViewData["movieId"] = data.Id;
                    return View(movieDto);
                }

                data.MovieName=movieDto.movieName;
                data.imageUrl = movieDto.imgUrl;
                data.DirectorId = Convert.ToInt32(movieDto.DirectorId);
                data.ImdbId = Convert.ToInt32(movieDto.ImdbId);

                mvcontext.Movies.Update(data);
                mvcontext.SaveChanges();
            }
            

            return RedirectToAction("GetMovies","home");
        }

        public IActionResult Delete(int id)
        {
            using(MovieContext mvcontext = new())
            {
                var data = mvcontext.Movies.FirstOrDefault(x => x.Id == id);
                if (data == null)
                {
                    return RedirectToAction("GetMovies", "home");
                }
                mvcontext.Movies.Remove(data);
                mvcontext.SaveChanges();
            }

           
           
            return RedirectToAction("GetMovies","home");
        }

        public IActionResult AddDirector()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDirector(DirectorDto directors)
        {
            if (!ModelState.IsValid)
            {
                return View(directors);
            }
            using (MovieContext mvcontext = new())
            {
                Directors director = new Directors()
                {
                    FirstName = directors.FirstName,
                    LastName = directors.LastName,
                };

                mvcontext.Directorss.Add(director);
                mvcontext.SaveChanges();
            }
            return RedirectToAction("AddMovie", "home");
        }

    }
}
