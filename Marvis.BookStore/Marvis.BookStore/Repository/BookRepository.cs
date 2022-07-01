using Marvis.BookStore.Data;
using Marvis.BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvis.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        //public BookRepository()
        //{
        //}

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                Language = model.Language,
                Totalpages = model.Totalpages.HasValue ? model.Totalpages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };
            //Mapping to database
            await _context.Books.AddAsync(newBook);
            //To hit the database
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        Totalpages = book.Totalpages
                    });
                }
            }
            return DataSource();
        }
        public async Task<BookModel> GetBookById(int id)
        {
            //Return details of a book
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    Totalpages = book.Totalpages
                };
                return bookDetails;
            }
            return null;

             //_context.Books.Where(x => x.Id == id).FirstOrDefault();
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
