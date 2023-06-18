using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationRider.Data;
using WebApplicationRider.Models;

namespace WebApplicationRider.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public BlogPostController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<BlogPost> blogPostsList = _db.BlogPosts.Include(bp => bp.Category);
            return View(blogPostsList);
        }
        
        //Get
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_db.Categories, "Id", "Name");
            return View();
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Create(BlogPost newPost)
        {
            newPost.Category = _db.Categories.Find(newPost.CategoryId);
            if (ModelState.IsValid)
            {
                _db.BlogPosts.Add(newPost);
                _db.SaveChanges();
                TempData["result"] = "Successfully added " + newPost.Title + "!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}