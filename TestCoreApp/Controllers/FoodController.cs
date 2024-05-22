using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestCoreApp.Data;
using TestCoreApp.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace TestCoreApp.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {
        public FoodController(AppDbContext db , IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }

        private readonly IHostingEnvironment _host; 
        private readonly AppDbContext _db;

        public IActionResult Index()
        {
            IEnumerable<Food> FoodsList = _db.Foods.Include(c => c.Category).ToList();
            return View(FoodsList);
        }

        //GET
        public IActionResult New()
        {
            createSelectList();
            return View(); 
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Food food)
        {
            if (food.Name == "100")
            {
                ModelState.AddModelError("Name", "Name can't equal 100");
            }
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (food.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    fileName = food.clientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    food.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    food.imagePath = fileName;
                }
                _db.Foods.Add(food);
                _db.SaveChanges();
                TempData["successData"] = "food has been added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(food);
            }
        }

        public void createSelectList(int selectId = 1)
        {
            //List<Category> categories = new List<Category> {
            //  new Category() {Id = 0, Name = "Select Category"},
            //  new Category() {Id = 1, Name = "Computers"},
            //  new Category() {Id = 2, Name = "Mobiles"},
            //  new Category() {Id = 3, Name = "Electric machines"},
            //};
            List<Category> categories = _db.Categories.ToList();
            SelectList listFoods = new SelectList(categories, "Id", "Name", selectId);
            ViewBag.CategoryList = listFoods;
        }

        //GET
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var food = _db.Foods.Find(Id);
            if (food == null)
            {
                return NotFound();
            }
            createSelectList(food.CategoryId);
            return View(food);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Food food)
        {
            if (food.Name == "100")
            {
                ModelState.AddModelError("Name", "Name can't equal 100");
            }
            if (ModelState.IsValid)
            {
                _db.Foods.Update(food);
                _db.SaveChanges();
                TempData["successData"] = "food has been updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(food);
            }
        }

        //GET
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var food = _db.Foods.Find(Id);
            if (food == null)
            {
                return NotFound();
            }
            createSelectList(food.CategoryId);
            return View(food);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Deletefood(int? Id)
        {
            var food = _db.Foods.Find(Id);
            if (food == null)
            {
                return NotFound();
            }
            _db.Remove(food);
           _db.SaveChanges();
            TempData["successData"] = "food has been deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
