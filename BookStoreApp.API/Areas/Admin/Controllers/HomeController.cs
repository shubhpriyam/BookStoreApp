using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.BookStore.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
