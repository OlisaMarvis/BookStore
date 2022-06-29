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
                new BookModel() { Id = 1, Title = "MVC", Author = "Olisa", Description = "This is the description for the MVC book", Category="Programming", Language="English", Totalpages=134 },
                new BookModel() { Id = 2, Title = "Dot Net Core", Author = "Olisa", Description = "This is the description for the Dot Net Core book", Category="framework", Language="Chinese", Totalpages=567 },
                new BookModel() { Id = 3, Title = "C#", Author = "Marvis", Description = "This is the description for the C# book", Category="Developer", Language="Hindi", Totalpages=897 },
                new BookModel() { Id = 4, Title = "Java", Author = "OlisaMarvis", Description = "This is the description for the Java book", Category="Concept", Language="English", Totalpages=564 },
                new BookModel() { Id = 5, Title = "Php", Author = "OlisaMarvis", Description = "This is the description for the PHP book", Category="Programming", Language="English", Totalpages=100 },
                new BookModel() { Id = 5, Title = "Azure DevOps", Author = "OlisaMarvis", Description = "This is the description for the Azure DevOps book", Category="DevOps", Language="English", Totalpages=800 },
            };
        }
    }
}
