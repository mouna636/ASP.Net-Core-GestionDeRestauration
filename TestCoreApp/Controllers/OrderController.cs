﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestCoreApp.Data;
using TestCoreApp.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace TestCoreApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public OrderController(AppDbContext db, IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }

        private readonly IHostingEnvironment _host;
        private readonly AppDbContext _db;
        public IActionResult Index()
        {
            IEnumerable<Order> OrdersList = _db.Orders.Include(c => c.Food).ToList();
            return View(OrdersList);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Order order)
        {
            if (order.Name == "100")
            {
                ModelState.AddModelError("Name", "Name can't equal 100");
            }

            if (ModelState.IsValid)
            {
                // Ajouter la commande à la base de données
                _db.Orders.Add(order);
                _db.SaveChanges();

                TempData["successData"] = "Order has been added successfully";
                return RedirectToAction("Index");
            }
            else
            {
               
                return View(order);
            }
        }









        //GET
        public IActionResult New()
        {
            createSelectList();

            return View();
        }
        public void createSelectList(int selectId = 1)
        {
            List<Food> foods = _db.Foods.ToList();
            SelectList listFoods = new SelectList(foods, "Id", "Name", selectId);
            ViewBag.FoodList = listFoods;
        }


        //GET
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var order = _db.Orders.Find(Id);
            if (order == null)
            {
                return NotFound();
            }
            createSelectList(order.FoodId);
            return View(order);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOrder(int? Id)
        {
            var order = _db.Orders.Find(Id);
            if (order == null)
            {
                return NotFound();
            }
            _db.Remove(order);
            _db.SaveChanges();
            TempData["successData"] = "food has been deleted successfully";
            return RedirectToAction("Index");
        }
    }




}
