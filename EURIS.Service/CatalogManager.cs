using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.Entities;
using System.Data.Entity;

namespace EURIS.Service
{
    public class CatalogManager
    {
        LocalDbEntities context = new LocalDbEntities();

        public List<Catalog> GetCatalogs()
        {
            List<Catalog> catalogs = new List<Catalog>();

            catalogs = (from item in context.Catalog
                        select item).ToList();

            return catalogs;
        }

        public Catalog GetCatalog(int id)
        {
            var catalog = context.Catalog.FirstOrDefault(p => p.Id == id);

            return catalog;
        }

        public bool CreateCatalog(Catalog catalog)
        {
            bool IsSuccess = false;
            try
            {
                context.Catalog.Add(catalog);
                context.SaveChanges();

                IsSuccess = true;
                //Add to Log
            }
            catch (Exception ex)
            {
                //Add to Log
            }

            return IsSuccess;
        }

        public bool EditCatalog(Catalog catalog)
        {
            bool IsSuccess = false;
            try
            {
                context.Catalog.Attach(catalog);
                context.Entry(catalog).State = System.Data.EntityState.Modified;
                context.SaveChanges();

                IsSuccess = true;
                //Add to Log
            }
            catch (Exception ex)
            {
                //Add to Log
            }

            return IsSuccess;
        }

        public bool DeleteCatalog(int id)
        {
            bool IsSuccess = false;
            try
            {
                var catalog = context.Catalog.FirstOrDefault(p => p.Id == id);

                foreach (var item in catalog.Catalog_Products.ToList())
                {
                    context.Entry(item).State = System.Data.EntityState.Deleted;
                }

                context.SaveChanges();
                context.Entry(catalog).State = System.Data.EntityState.Deleted;
                context.SaveChanges();

                IsSuccess = true;
                //Add to Log
            }
            catch (Exception ex)
            {
                //Add to Log
            }

            return IsSuccess;
        }

        #region Products

        public bool AddProduct(Catalog catalog, int product_id)
        {
            bool IsSuccess = false;
            try
            {
                Catalog_Products item = new Catalog_Products();
                item.Catalog_Id = catalog.Id;
                item.Product_Id = product_id;

                catalog.Catalog_Products.Add(item);

                context.Catalog.Attach(catalog);
                context.Entry(catalog).State = System.Data.EntityState.Modified;
                context.SaveChanges();

                IsSuccess = true;
                //Add to Log
            }
            catch (Exception ex)
            {
                //Add to Log
            }

            return IsSuccess;

        }

        public bool DeleteProduct(int id)
        {
            bool IsSuccess = false;
            try
            {
                var catalog = context.Catalog_Products.FirstOrDefault(p => p.Id == id);
                context.Entry(catalog).State = System.Data.EntityState.Deleted;
                context.SaveChanges();

                IsSuccess = true;
                //Add to Log
            }
            catch (Exception ex)
            {
                //Add to Log
            }

            return IsSuccess;
        }

        #endregion
    }
}
