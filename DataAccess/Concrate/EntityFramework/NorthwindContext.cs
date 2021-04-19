using Entities.Concrate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrate.EntityFramework
{
    //Context: Db tablolari ile proje classlarini baglamak
    public class NorthwindContext : DbContext
    {
        //Bu metod projenin hangi veritabani ile ilişkilendirecegimiz yer
        //Product nesnemi veritabanindaki Products ile bağla
        //Peki neden tablo sütun isimlerini belirtmedik ? Onları nesnemizin özelliklerinin 
        //isimlerini tablo sütun isimleriyle aynı yaparak entitiyframework ile hallettik.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        //Nesneleri birbirine karşlılık getiriyoruz
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Worker> Workers { get; set; }
        public DbSet<Order> Orders { get; set; }

        //Custom Mapping
        //Yukarıdaki gibi nesnelerimizi veritabanı tablolarına karsılık getirirken, veritabanı tablo ve alan adlarına dikkat ediyoruz.
        //Bu zorunlu mu ? Tabi ki degil. Yani Personel varlıgımızı illa veritabanındaki Employees ismiyle degistirmemize gerek yok. Hatta sütun isimlerine bile adapte etmeye gerek yok!
        //Bunu OnModelCreating metoduyla çözüyoruz.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().ToTable("Employees");
            modelBuilder.Entity<Worker>().Property(p => p.Id).HasColumnName("EmployeeID");
            modelBuilder.Entity<Worker>().Property(p => p.Name).HasColumnName("FirstName");
            modelBuilder.Entity<Worker>().Property(p => p.Surname).HasColumnName("LastName");

        }

        
    }
}