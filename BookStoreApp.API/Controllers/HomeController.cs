using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Data = new BookModel() { Author = "Mark Manson", Title = "The Subtle Art of Not Giving a F*ck" };
            return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
