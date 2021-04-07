using IMS_With_Code_First.Models;
using IMS_With_Code_First.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_With_Code_First.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        CategoryRepository categoryRepository = new CategoryRepository();

        public ActionResult Index()
        {
            /*InventoryDbContext dbContext = new InventoryDbContext();
             var list = dbContext.Products.ToList();
             return View(list);*/
            return View(productRepository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            ViewData["categories"] = categoryRepository.GetAll().ToList();
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Product product)
        {
            productRepository.Insert(product);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            ViewData["categories"] = categoryRepository.GetAll().ToList();
            return View(productRepository.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productRepository.Update(product);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            productRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}