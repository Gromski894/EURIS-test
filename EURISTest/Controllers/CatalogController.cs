using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EURIS.Entities;
using EURIS.Service;

namespace EURISTest.Controllers
{
    public class CatalogController : Controller
    {
        //
        // GET: /Catalog/

        public ActionResult Index()
        {
            CatalogManager catalogManager = new CatalogManager();
            List<Catalog> catalogs = catalogManager.GetCatalogs();

            ViewBag.Catalogs = catalogs;

            return View();
        }

        //
        // GET: /Catalog/Details/5

        public ActionResult Details(int id = 0)
        {
            CatalogManager catalogManager = new CatalogManager();
            Catalog catalog = catalogManager.GetCatalog(id);

            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        //
        // GET: /Catalog/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Catalog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                CatalogManager catalogManager = new CatalogManager();
                bool success = catalogManager.CreateCatalog(catalog);

                if (success)
                    return RedirectToAction("Index");
                //else
                //display error
            }

            return View(catalog);
        }

        //
        // GET: /Catalog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CatalogManager catalogManager = new CatalogManager();
            Catalog catalog = catalogManager.GetCatalog(id);

            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        //
        // POST: /Catalog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                CatalogManager catalogManager = new CatalogManager();
                bool success = catalogManager.EditCatalog(catalog);

                if (success)
                    return RedirectToAction("Index");
                //else
                //display error
            }
            return View(catalog);
        }

        //
        // GET: /Catalog/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CatalogManager catalogManager = new CatalogManager();
            Catalog catalog = catalogManager.GetCatalog(id);

            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        //
        // POST: /Catalog/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatalogManager catalogManager = new CatalogManager();
            bool success = catalogManager.DeleteCatalog(id);

            //if (success)
            return RedirectToAction("Index");
            //else
            //display error
        }


        #region Products

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(int catalog_id, string txtProductCode)
        {
            CatalogManager catalogManager = new CatalogManager();
            Catalog catalog = catalogManager.GetCatalog(catalog_id);

            ProductManager productManager = new ProductManager();
            Product product = productManager.GetProduct(txtProductCode);

            if (product != null)
            {
                bool success = catalogManager.AddProduct(catalog, product.Id);

                //if (success)
                    return RedirectToAction("Edit", new { id = catalog_id });
                //else
                    //show error
            }
            else
                return RedirectToAction("Edit", new { id = catalog_id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int cp_id)
        {
            CatalogManager catalogManager = new CatalogManager();
            bool success = catalogManager.DeleteProduct(cp_id);

            if (success)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Index");

        }

        #endregion
    }
}
