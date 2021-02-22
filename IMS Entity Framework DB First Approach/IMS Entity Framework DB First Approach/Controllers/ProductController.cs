using IMS_Entity_Framework_DB_First_Approach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_Entity_Framework_DB_First_Approach.Controllers
{
    public class ProductController : Controller
    {
        InventoryDbEntities context = new InventoryDbEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View(context.Products.ToList());
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["categories"] = context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewData["categories"] = context.Categories.ToList();
            return View(context.Products.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id,Product product)
        {
            var productToChange=context.Products.Find(id);
            productToChange.CategoryId = product.CategoryId;
            productToChange.ProductName = product.ProductName;
            productToChange.Price = product.Price;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(context.Products.Find(id));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(context.Products.Find(id));
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            context.Products.Remove(context.Products.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}