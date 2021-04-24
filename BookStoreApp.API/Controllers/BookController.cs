using Microsoft.AspNetCore.Mvc;
using BookStoreApp.BookStore.CustomBinder;
using BookStoreApp.BookStore.Repository;
using BookStoreApp.Contracts.Interface;
using BookStoreApp.Contracts.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository =null;
        private readonly IBookData _bookData;

        public BookController(IBookData bookData)
        {
            _bookRepository = new BookRepository();
            _bookData = bookData;
        }
        
        [Route("All-Books")]
        public async Task<IActionResult> GetAllBooks(string sortOrder, string title, int pageNumber =1, int pageSize=3)
        {
            int excludeRecord = pageNumber * pageSize - pageSize;
            ViewBag.sortParam = String.IsNullOrEmpty(sortOrder) ? "desc" : "";
            ViewBag.CurrentSortOrder = sortOrder;

            var data = await _bookData.GetAllBook();
            var count= _bookData.TotalBookCount();
            if (!String.IsNullOrEmpty(title))
            {
              data = data.Where(x => x.Title.ToLower().Contains(title.ToLower()) || x.Author.ToLower().Contains(title.ToLower()));
            }

            switch(sortOrder)
            {
                case "desc":
                    data = data.OrderByDescending(x => x.Title);
                    break;
                default:
                    data = data.OrderBy(x => x.Title);
                    break;

            }
            ViewBag.bookdata = data.Skip(excludeRecord).Take(pageSize);

            ViewBag.TotalCount = count;
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            return View();
        }

        [Route("Book-details/{id}", Name ="Bookdetailsbyid")]
        public async Task<IActionResult> GetBookById(int id)
        {
            //var data = _bookRepository.GetBookById(id);
            var data = await _bookData.GetBookById(id);
            return View(data);
        }

        public async Task<IActionResult> DeleteBookById(int id)
        {
            //var data = _bookRepository.GetBookById(id);
            var data = await _bookData.DeleteBookById(id);
            if (data == "success")
            {
                return RedirectToAction(nameof(GetAllBooks));
            }
            return RedirectToAction(nameof(GetAllBooks));
        }

        public async Task<IActionResult> UpdateBookById(int id)
        {
            var data = await _bookData.GetBookById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBookById(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                var id = await _bookData.UpdateBookById(bookModel);
                if (id != 0)
                {
                    var viewdata = await _bookData.GetBookById(id);
                    return View("GetBookById", viewdata);
                }
            }
            return View();
        }
        public ViewResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromForm] BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int value = await _bookData.CreateNewBook(bookModel);
                if (value > 0)
                {
                    return RedirectToAction(nameof(GetAllBooks));
                }
            }           
            return View();
        }
    }
}
