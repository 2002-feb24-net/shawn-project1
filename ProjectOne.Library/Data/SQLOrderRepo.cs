using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Data
{
    public class SQLOrderRepo  : IOrderRepo
    {
        private readonly ProjectOneContext context;
        public IEnumerable<object> Orders => throw new NotImplementedException();
        public SQLOrderRepo(ProjectOneContext context)
        {
            this.context = context;
        }
        public Orders Add(Orders order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }
        public Orders AddToCart(int id)
        {
            Products myModel = context.Products.FirstOrDefault(m => m.Id == id);
            var myOrder = new Orders();
            myOrder.Id = myModel.Id;
            context.Orders.Add(myOrder); 
            context.SaveChanges();
            var order = new Orders();
            return order;
        }
        public Orders Delete(int id)
        {
            Orders order = context.Orders.Find(id);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            return order;
        }
        public IEnumerable<Orders> GetAllOrders()
        {
            return context.Orders;
        }
        public Orders GetOrders(int id)
        {
            return context.Orders.Find(id);
        }
        public Orders Update(Orders orderChanges)
        {
            var order = context.Orders.Attach(orderChanges);
            order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return orderChanges;
        }
        public Orders GetAllOrders(int cart)
        {
            throw new NotImplementedException();
        }
    }
}