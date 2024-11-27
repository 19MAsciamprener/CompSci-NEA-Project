using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahApps.Models
{
    public class BudgetDbContext : DbContext
    {
        public DbSet<BudgetClass> BudgetTables { get; set; }

        public string PATH = @"E:\GIT\CompSci-NEA-Project\Budget Application Test\BudgetDB.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={PATH}");
    }
}
