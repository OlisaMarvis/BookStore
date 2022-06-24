using Marvis.BookStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace Marvis.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            //return DataSource().Where(x => x.Title == title && x.Author == authorName).ToList(); OR use

            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();

        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1, Title = "MVC", Author = "Olisa" },
                new BookModel() { Id = 2, Title = "MVC", Author = "Olisa" },
                new BookModel() { Id = 3, Title = "C#", Author = "Marvis" },
                new BookModel() { Id = 4, Title = "Java", Author = "OlisaMarvis" },
                new BookModel() { Id = 5, Title = "Php", Author = "OlisaMarvis" },
            };
        }
    }
}
