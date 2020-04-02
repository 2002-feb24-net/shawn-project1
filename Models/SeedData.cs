using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectOne.Data;
using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectOneContext(serviceProvider.GetRequiredService<DbContextOptions< ProjectOneContext>>()))
            {
                if (context.Store.Any())
                {
                    return;
                }
                context.Customer.AddRange(
                    new Customer
                    {
                        FirstName = "Test",
                        LastName = "Account",
                        PhoneNumber = "555-555-5555",
                        PreferredLocation = "Dallas",
                        EmailAddress = "something@email.com",
                        Password = "password123"
                    }
                );
                context.Order.AddRange(
                    new Order
                    {
                        CartID = 1,
                        QuantitySold = 1,
                        PriceTotal = 122.44M,
                        StoreLocation = "Dallas",
                        CustomerID = 1,
                        ProductID = 1
                    },
                    new Order
                    {
                        CartID = 1,
                        QuantitySold = 1,
                        PriceTotal = 155.21M,
                        StoreLocation = "Dallas",
                        CustomerID = 1,
                        ProductID = 3
                    }
                );
                context.Store.AddRange(
                    new Store
                    {
                        Inventory = "AMD",
                        State = "Tennessee",
                        City = "Memphis",
                        TotalSalesAmount = 0,
                        TotalSalesQuantity = 0
                    },
                    new Store
                    {
                        Inventory = "Intel",
                        State = "Arizona",
                        City = "Phoenix",
                        TotalSalesAmount = 0,
                        TotalSalesQuantity = 0
                    },
                    new Store
                    {
                        Inventory = "AMD/Intel",
                        State = "Texas",
                        City = "Dallas",
                        TotalSalesAmount = 0,
                        TotalSalesQuantity = 0
                    }
                );
                context.Product.AddRange(
                    new Product
                    {
                        Brand = "AMD",
                        Series = "Ryzen",
                        Model = "2300X",
                        Price = 120.95M,
                        Quantity = 30
                    },
                    new Product
                    {
                        Brand = "AMD",
                        Series = "Ryzen",
                        Model = "2600X",
                        Price = 199.39M,
                        Quantity = 20
                    },
                    new Product
                    {
                        Brand = "AMD",
                        Series = "Ryzen",
                        Model = "3950X",
                        Price = 339.84M,
                        Quantity = 10
                    },
                    new Product
                    {
                        Brand = "Intel",
                        Series = "Core",
                        Model = "i3-7100",
                        Price = 125.44M,
                        Quantity = 30
                    },
                    new Product
                    {
                        Brand = "Intel",
                        Series = "Core",
                        Model = "i5-7400",
                        Price = 188.73M,
                        Quantity = 20
                    },
                    new Product
                    {
                        Brand = "Intel",
                        Series = "Core",
                        Model = "i7-7700",
                        Price = 347.10M,
                        Quantity = 10
                    }
                );
                context.SaveChanges();
            }
        }
    }
}