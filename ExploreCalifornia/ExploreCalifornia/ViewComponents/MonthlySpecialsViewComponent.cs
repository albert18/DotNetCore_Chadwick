using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.ViewComponents
{
    [ViewComponent]
    public class MonthlySpecialsViewComponent : ViewComponent
    {
        private readonly BlogDataContext _db;

        public MonthlySpecialsViewComponent(BlogDataContext db)
        {
            this._db = db;
        }

        public IViewComponentResult Invoke()
        {
            //var specials = _db

            //return "Resuable Components";
            return View();
        }
            
    }
}
