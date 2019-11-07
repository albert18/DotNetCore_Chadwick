using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
    //[Route("blog")]

    public class BlogController : Controller
    {
        private readonly BlogDataContext _db;

        public BlogController(BlogDataContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Route("blog/{year:int}/{month:int}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = new Post
            {
                Title = "My blog post",
                Posted = DateTime.Now,
                Author = "Albert",
                Body = "This is a great blog"
            };

            return View(post);
            //return new ContentResult { Content = string.Format("Year: {0}, Month: {1}, Key: {2}", year,month,key) };
        }


        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Data
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("create")]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;

            _db.Posts.Add(post);
            _db.SaveChanges();

            return View();
        }

        //First approach OR you can use BIND attribute
        //public class classCreatePostRequest
        //{
        //    classCreatePostRequest post

        //    public string Title { get; set; }
        //    public string Body { get; set; }
        //}

        //public IActionResult Post(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new ContentResult { Content = "null" };
        //    }
        //    else
        //    {
        //        return new ContentResult { Content = id.ToString() };
        //    }
        //}
    }
}