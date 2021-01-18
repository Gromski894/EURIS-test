using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EURIS.Service;
using EURIS.Entities;

namespace EURISTest.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            ProductManager productManager = new ProductManager();
            List<Product> products = productManager.GetProducts();

            ViewBag.Products = products;

            return View();
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {
            ProductManager productManager = new ProductManager();
            Product product = productManager.GetProduct(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductManager productManager = new ProductManager();
                bool success = productManager.CreateProduct(product);

                if(success)
                    return RedirectToAction("Index");
                //else
                    //display error
            }

            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProductManager productManager = new ProductManager();
            Product product = productManager.GetProduct(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductManager productManager = new ProductManager();
                bool success = productManager.EditProduct(product);

                if (success)
                    return RedirectToAction("Index");
                //else
                //display error
            }
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProductManager productManager = new ProductManager();
            Product product = productManager.GetProduct(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductManager productManager = new ProductManager();
            bool success = productManager.DeleteProduct(id);

            //if (success)
                return RedirectToAction("Index");
            //else
            //display error
        }
    }
}
