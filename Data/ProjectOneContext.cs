using Microsoft.EntityFrameworkCore;
using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Data
{
    public class ProjectOneContext : DbContext
    {

        public ProjectOneContext(DbContextOptions<ProjectOneContext> options) : base(options){}
        public DbSet<ProjectOne.Models.Customer> Customer { get; set; }
        public DbSet<ProjectOne.Models.Product> Product { get; set; }
        public DbSet<ProjectOne.Models.Order> Order { get; set; }
        public DbSet<ProjectOne.Models.Store> Store { get; set; }
    }
}
