using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.Entities;
using System.Data.Entity;

namespace EURIS.Service
{
    public class ProductManager
    {
        LocalDbEntities context = new LocalDbEntities(); 

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            
            products = (from item in context.Product
                        select item).ToList();

            return products;
        }

        public Product GetProduct(int id)
        {
            var product = context.Product.FirstOrDefault(p => p.Id == id);

            return product;
        }

        public Product GetProduct(string code)
        {
            var product = context.Product.FirstOrDefault(p => p.Code == code);

            return product;
        }

        public bool CreateProduct(Product product)
        {
            bool IsSuccess = false;
            try
            {
                context.Product.Add(product);
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

        public bool EditProduct(Product product)
        {
            bool IsSuccess = false;
            try
            {
                context.Product.Attach(product);
                context.Entry(product).State = System.Data.EntityState.Modified;
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
                var product = context.Product.FirstOrDefault(p => p.Id == id);
                context.Entry(product).State = System.Data.EntityState.Deleted;
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
    }
}
