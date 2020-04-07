using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectOne.Models;

namespace ProjectOne.Data
{
    public interface ICustomerRepo
    {
        Customers Add(Customers order);
        Customers Update(Customers orderChanges);
        Customers Delete(int id);
        Customers FindByName(string cust);
    }
}