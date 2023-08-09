namespace playstation.Models
{
    public class VideoGame
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal CurrentPrice { get; set; } 
        public string Publisher { get; set; }
        public DateTime ReleasedDate { get; set; }
        public string Genre { get; set; }

        //public IEnumerable<Category> Categories { get; set; }
    }
}
