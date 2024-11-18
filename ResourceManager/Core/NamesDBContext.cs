using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManager.Core
{
    internal class NamesDBContext : DbContext
    {
        public DbSet<Names> names { get: set: }

        public string path = @"C:\Temp\Names.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={path}");
    }
}
