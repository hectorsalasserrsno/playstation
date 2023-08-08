using Dapper;
using Microsoft.AspNetCore.Mvc;
using playstation.Models;
using System.Data;

namespace playstation
{
    public class VideoGameRepository: IVideoGameRepository
    {
        private readonly IDbConnection _conn;

        public VideoGameRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<VideoGame> GetAllVideoGames()
        {
            return _conn.Query<VideoGame>("SELECT * FROM videogames;");
        }
        public VideoGame GetVideoGame(int id)
        {
            return _conn.QuerySingle<VideoGame>("SELECT * FROM videogames WHERE id = @id;", new { id = id });
        }

        public void UpdateVideoGame(VideoGame videogame)
        {
            _conn.Execute("UPDATE videogames SET Name = @name, " +
                "CurrentPrice = @currentprice, Publisher = @publisher, ReleasedDate = @releasedDate," +
                " Genre = @genre WHERE id = @id;",
             new { id = videogame.id, name = videogame.Name, 
                 currentprice = videogame.CurrentPrice, publisher = videogame.Publisher, 
                 releasedDate = videogame.ReleasedDate, genre = videogame.Genre });
        }

 
    }
}
