using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using playstation.Models;

namespace playstation.Controllers
{
    public class VideoGameController : Controller
    {
        private readonly IVideoGameRepository repo;

        public VideoGameController(IVideoGameRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var games = repo.GetAllVideoGames();
            return View(games);
        }
        public IActionResult ViewVideoGame(int id)
        {
            var vidGame = repo.GetVideoGame(id);
            return View(vidGame);

        }

        public IActionResult UpdateVideoGame(int id)
        {
            VideoGame video = repo.GetVideoGame(id);
            if (video == null)
            {
                return View("VideoGameNotFound");
            }
            return View(video);
        }
        public IActionResult UpdateVideoGameToDatabase(VideoGame videogame)
        {
            repo.UpdateVideoGame(videogame);

            return RedirectToAction("ViewVideoGame", new { id = videogame.id });
        }
        public IActionResult InsertVideoGame()
        {
            var vidGame = new VideoGame();
            return View(vidGame);
        }
        public IActionResult InsertVideoGameToDatabase(VideoGame videogameToInsert)
        {
            repo.InsertVideoGame(videogameToInsert);
            return RedirectToAction("Index");
        }
    }

}
