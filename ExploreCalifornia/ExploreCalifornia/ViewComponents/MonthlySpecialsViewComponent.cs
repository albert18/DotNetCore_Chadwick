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
        public string Invoke()
        {
            return "Resuable Components";
        }
            
    }
}
