using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectOne.Models;

namespace ProjectOne.Data
{
    public interface IProductRepo
    {
        Products Add(Products order);
        Products Update(Products orderChanges);
        Products Delete(int id);
        Products FindByName(string item);
        Products FindByID(int id);
    }
}