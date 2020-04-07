using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectOne.Models;

namespace ProjectOne.Data
{
    public interface IOrderRepo
    {
        Orders Add(Orders order);
        Orders Update(Orders orderChanges);
        Orders Delete(int id);
        Orders AddToCart(int id);
    }
}