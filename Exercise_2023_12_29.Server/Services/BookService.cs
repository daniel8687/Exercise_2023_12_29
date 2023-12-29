using Exercise_2023_12_29.Server.Models;
using Exercise_2023_12_29.Server.Models.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Headers;
using Exercise_2023_12_29.Server.Models.Enums;
using Newtonsoft.Json;

namespace Exercise_2023_12_29.Server.Services
{
    public class BookService : IBookService
    {
        private const string _cacheKey = "book";
        private const int _cacheTimeSeconds = 30;
        private readonly IMemoryCache _memoryCache;
        private HttpClient _httpClient;

        public BookService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _httpClient = new HttpClient();
        }

        private async Task<HttpResponseMessage> GetApi(string url)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return await _httpClient.GetAsync(url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Book> GetBooks(string[] isbnValues)
        {
            isbnValues = isbnValues.ToList().Distinct().ToArray();
            var books = new List<Book>();
            var index = 1;

            foreach (var isbn in isbnValues)
            {
                var book = GetBook(isbn);
                if (book is not null)
                {
                    book.RowNumber = index;
                    books.Add(book);
                    index++;
                }
            }
            
            return books;
        }

        private Book? GetBook(string isbn)
        {
            Book? book = null;
            var newCacheKey = $"{_cacheKey}_isbn_{isbn}";

            if (!_memoryCache.TryGetValue(newCacheKey, out book))
            {
                book = GetBookFromApiAsync(isbn).Result;
                book.DataRetrievalType = DataRetrievalType.Server.ToString();
                _memoryCache.Set(newCacheKey, book,
                    new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheTimeSeconds)));
            }
            else if(book is not null)
                book.DataRetrievalType = DataRetrievalType.Cache.ToString();

            return book;
        }

        private async Task<Book> GetBookFromApiAsync(string isbn)
        {
            Book book = null;
            var noneValue = "N/A";
            var getApiResponse = await GetApi($"https://openlibrary.org/api/books?bibkeys=ISBN:{isbn}&format=json&jscmd=data");
            if (getApiResponse.IsSuccessStatusCode)
            {
                var jsonContent = await getApiResponse.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, ISBN>>(jsonContent);
                if (jsonObject is not null && jsonObject.ContainsKey($"ISBN:{isbn}"))
                {
                    var isbnObject = jsonObject[$"ISBN:{isbn}"];
                    book = new Book();
                    book.ISBN = isbn;
                    book.Title = string.IsNullOrEmpty(isbnObject.title) ? noneValue : isbnObject.title;
                    book.Subtitle = string.IsNullOrEmpty(isbnObject.subtitle) 
                        ? noneValue : isbnObject.subtitle;
                    book.AuthorNames = isbnObject.authors is null || isbnObject.authors.Count() <= 0 
                        ? noneValue : string.Join(";", isbnObject.authors.Select(x => x.name).ToArray());
                    book.NumberOfPages = isbnObject.number_of_pages is null || isbnObject.number_of_pages <= 0 
                        ? noneValue : isbnObject.number_of_pages.ToString();
                    book.PublishDate = string.IsNullOrEmpty(isbnObject.publish_date)
                        ? noneValue : isbnObject.publish_date;
                }
            }
            return book;
        }
    }
}