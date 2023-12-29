using Exercise_2023_12_29.Server.Models.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise_2023_12_29.Server.Models
{
    public class Book
    {
        public long RowNumber { get; set; }
        public string DataRetrievalType { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string AuthorNames { get; set; }
        public string NumberOfPages { get; set; }
        public string PublishDate { get; set; }
    }
}
