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

        public void DeleteVideoGame(VideoGame videogame)
        {
            _conn.Execute("DELETE FROM videogames WHERE id= @id;", new { id = videogame.id });
        }

        public IEnumerable<VideoGame> GetAllVideoGames()
        {
            return _conn.Query<VideoGame>("SELECT * FROM videogames;");
        }

       

        public VideoGame GetVideoGame(int id)
        {
            return _conn.QuerySingle<VideoGame>("SELECT * FROM videogames WHERE id = @id;", new { id = id });
        }

        public void InsertVideoGame(VideoGame videoGameToInsert)
        {
            _conn.Execute("INSERT INTO videogames (NAME, CURRENTPRICE, PUBLISHER, RELEASEDDATE, GENRE) VALUES (@name, @currentprice, @publisher," +
                " @releasedDate, @genre);",
        new { name = videoGameToInsert.Name, currentprice = videoGameToInsert.CurrentPrice, publisher = videoGameToInsert.Publisher,
            releaseddate = videoGameToInsert.ReleasedDate, genre = videoGameToInsert.Genre });
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
