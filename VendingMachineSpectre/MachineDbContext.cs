using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VendingMachineSpectre;

internal class MachineDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = vendmach.db");
    }

    public DbSet<Product>? Products { get; set; }
    public DbSet<Nutrition>? Nutritions { get; set; }
    public DbSet<User>? Users { get; set; }
}

