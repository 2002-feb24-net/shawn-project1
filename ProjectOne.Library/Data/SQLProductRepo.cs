using Microsoft.EntityFrameworkCore;
using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Data
{
    public class SQLProductRepo  : IProductRepo
    {
        private readonly ProjectOneContext context;
        public SQLProductRepo(ProjectOneContext context)
        {
            this.context = context;
        }
        public Products Add(Products order)
        {
            context.Products.Add(order);
            context.SaveChanges();
            return order;
        }
        public Products Delete(int id)
        {
            Products order = context.Products.Find(id);
            if (order != null)
            {
                context.Products.Remove(order);
                context.SaveChanges();
            }
            return order;
        }
        public IEnumerable<Products> GetAllProducts()
        {
            return context.Products;
        }



        public Products GetProducts(int Id)
        {
            return context.Products.Find(Id);
        }
        public Products Update(Products orderChanges)
        {
            var order = context.Products.Attach(orderChanges);
            order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return orderChanges;
        }

        public Products FindByName(string item)
        {
            Products produ = context.Products
             .FirstOrDefault(m => m.Item == item);
            return produ;
        }

        public Products FindByID(int id)
        {
            Products produ = context.Products
             .FirstOrDefault(m => m.Id == id);
            return produ;
        }

    }
}