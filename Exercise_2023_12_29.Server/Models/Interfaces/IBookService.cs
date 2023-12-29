namespace Exercise_2023_12_29.Server.Models.Interfaces
{
    public interface IBookService
    {
        public IEnumerable<Book> GetBooks(string[] isbnArra);
    }
}
