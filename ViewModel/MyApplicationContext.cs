using MedCatalog.Model;
using Microsoft.EntityFrameworkCore;

namespace MedCatalog.ViewModel
{
    public class MyApplicationContext : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-N6GODSK;Database=DrugsDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
