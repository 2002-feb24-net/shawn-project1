using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectOne.Models;

namespace ProjectOne.Data
{
    public class MockOrderRepository : IOrderRepo
    {
        private List<Orders> _OrderList;
        public Orders Add(Orders order)
        {
            order.Id = _OrderList.Max(e => e.Id) + 1;
            _OrderList.Add(order);
            return order;
        }
        public Orders AddToCart(int id)
        {
            throw new NotImplementedException();
        }
        public Orders Delete(int id)
        {
            Orders order = _OrderList.FirstOrDefault(e => e.Id == id);
            if (order != null)
            {
                _OrderList.Remove(order);
            }
            return order;
        }
        public IEnumerable<Orders> GetAllOrders()
        {
            return _OrderList;
        }
        public Orders GetOrders(int Id)
        {
            return _OrderList.FirstOrDefault(e => e.Id == Id);
        }
        public Orders Update(Orders ordersChanges)
        {
            Orders order = _OrderList.FirstOrDefault(e => e.Id == ordersChanges.Id);
            if (order != null)
            {
                order.Item = ordersChanges.Item;
                order.Price = ordersChanges.Price;
                order.Quantity = ordersChanges.Quantity;
                order.Customer = ordersChanges.Customer;
                order.DateAndTime = ordersChanges.DateAndTime;
                order.Cart = ordersChanges.Cart;
            }
            return order;
        }
    }
}