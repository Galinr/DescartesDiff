using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiffLibrary.DataBase
{
    public class DiffDbContext : DbContext
    {
        public DiffDbContext(DbContextOptions<DiffDbContext> options) : base(options) { }

        public DbSet<Models.Data> data { get; set; }
    }
}
