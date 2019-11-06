using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post(int? id)
        {
            if (id == null)
            {
                return new ContentResult { Content = "null" };
            }
            else 
            {
                return new ContentResult { Content = id.ToString() };
            }

            
        }
    }
}