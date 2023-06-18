using Microsoft.AspNetCore.Mvc;
using WebApplicationRider.Data;
using WebApplicationRider.Models;

namespace WebApplicationRider.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //Get - create
        public IActionResult Create()
        {
            return View();
        }
        
        //Post - create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot be the same as the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["result"] = "Successfully added " + obj.Name + "!";
                return RedirectToAction("Index");
            }

            return View();
        }
        
        //Get - edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }
            
            return View(categoryFromDb);
        }
        
        //Post - edit
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot be the same as the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["result"] = "Successfully edited " + obj.Name + "!";
                return RedirectToAction("Index");
            }

            return View();
        }
        
        //Get - delete
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            
            var categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        public IActionResult DeletePost(Category obj)
        {
            if (obj == null)
                return NotFound();

            if (_db.Categories.Contains(obj))
            {
                var name = obj.Name;
                TempData["result"] = "Successfully deleted category!";
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}