using Microsoft.AspNetCore.Mvc;
using playstation.Models;

namespace playstation
{
    public interface IVideoGameRepository
    {
        public IEnumerable<VideoGame> GetAllVideoGames();

        public VideoGame GetVideoGame(int id);

        public void UpdateVideoGame(VideoGame videoGame);

        public void InsertVideoGame(VideoGame videoGameToInsert);

        public void DeleteVideoGame(VideoGame videogame);
    }
    
}
