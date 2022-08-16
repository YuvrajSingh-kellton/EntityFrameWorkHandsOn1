﻿using EntityFramework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class DemoDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }

        public DemoDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0P56O06;Database=EFDatabase;Trusted_Connection=True;");

        }
    }
}
