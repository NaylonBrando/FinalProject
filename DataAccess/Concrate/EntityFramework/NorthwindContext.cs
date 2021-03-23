using Entities.Concrate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrate.EntityFramework
{
    //Context: Db tablolari ile proje classlarini baglamak
    public class NorthwindContext : DbContext
    {
        //Bu metod projenin hangi veritabani ile ilişkilendirecegimiz yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        //Nesneleri birbirine karşlılık getiriyoruz
        public DbSet<Product> Products { get; set; } //Product nesnemi veritabanindaki Products ile bağla

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}