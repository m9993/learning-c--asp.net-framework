using IMS_With_Code_First.Models;
using IMS_With_Code_First.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_With_Code_First.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        public ActionResult Index()
        {
            /*InventoryDbContext dbContext = new InventoryDbContext();
            var list = dbContext.Categories.ToList();
            return View(list);*/
            return View(categoryRepository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryRepository.Insert(category);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(categoryRepository.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryRepository.Update(category);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}