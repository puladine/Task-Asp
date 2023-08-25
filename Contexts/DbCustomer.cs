using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tasks.Models;

namespace Tasks.Contexts
{
    public class DbCustomer : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=192.168.88.210; Database=Task;User ID=sa;Password=Ali1691001!;TrustServerCertificate=True");
        }
    }
}
