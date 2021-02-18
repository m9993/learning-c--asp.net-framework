using IMS_Entity_Framework_DB_First_Approach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_Entity_Framework_DB_First_Approach.Controllers
{
    public class CategoryController : Controller
    {
        InventoryDbEntities context = new InventoryDbEntities();

        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            return View(context.Categories.ToList());

            /*return View(context.Categories.Where(x=>x.CategoryName=="foods")); //Word */
            /*return View(context.Categories.Where(x => x.CategoryName.Contains("e")).ToList()); //Like*/
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var categoryToEdit=context.Categories.Find(id);
            return View(categoryToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            var categoryToEdit= context.Categories.Find(category.CategoryId);
            categoryToEdit.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var categoryDetails = context.Categories.Find(id);
            return View(categoryDetails);
        }


        [HttpGet]
        public ActionResult Delete(Category category,int id)
        {
            return View(context.Categories.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            context.Categories.Remove(context.Categories.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}