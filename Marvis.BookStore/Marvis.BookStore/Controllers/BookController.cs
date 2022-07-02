using Marvis.BookStore.Models;
using Marvis.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvis.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();

            return View(data); 
        }
        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel()
            {
                //Language = "2"
            };

            ViewBag.Language = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Igbo", Value = "1"},
                new SelectListItem(){Text = "English", Value = "2", Disabled = true},
                new SelectListItem(){Text = "Yoruba", Value = "3", Selected = true},
                new SelectListItem(){Text = "Hausa", Value = "4", Disabled = true},
            };


            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            //ViewBag.IsSuccess = false;
            //ViewBag.BookId = 0;

            ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");


            //To write your custom error messages
            //ModelState.AddModelError("", "Custom error message");
            //ModelState.AddModelError("", "Another Custom error message");

            return View();
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){ Id = 1, Text = "Igbo"},
                new LanguageModel(){ Id = 2, Text = "English"},
                new LanguageModel(){ Id = 3, Text = "French"},
            };
        }
    }
}
