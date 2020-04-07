using Microsoft.EntityFrameworkCore;
using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Data
{
    public class SQLCustomerRepo  : ICustomerRepo
    {
        private readonly ProjectOneContext context;
        public SQLCustomerRepo(ProjectOneContext context)
        {
            this.context = context;
        }
        public Customers Add(Customers order)
        {
            context.Customers.Add(order);
            context.SaveChanges();
            return order;
        }
        public Customers Delete(int id)
        {
            Customers order = context.Customers.Find(id);
            if (order != null)
            {
                context.Customers.Remove(order);
                context.SaveChanges();
            }
            return order;
        }
        public IEnumerable<Customers> GetAllCustomers()
        {
            return context.Customers;
        }



        public Customers GetCustomers(int Id)
        {
            return context.Customers.Find(Id);
        }
        public Customers Update(Customers orderChanges)
        {
            var order = context.Customers.Attach(orderChanges);
            order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return orderChanges;
        }

        public Customers FindByName(string cust)
        {
            Customers custo = context.Customers
             .FirstOrDefault(m => m.FirstName == cust);





            return custo;
        }
    }
}