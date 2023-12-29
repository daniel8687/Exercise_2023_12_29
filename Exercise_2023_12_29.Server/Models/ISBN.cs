namespace Exercise_2023_12_29.Server.Models
{
    public class ISBN
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public IEnumerable<ISBNAuthor> authors { get; set; }
        public long? number_of_pages { get; set; }
        public string publish_date { get; set; }
    }
}
