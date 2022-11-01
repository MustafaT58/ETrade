using ETrade.Entity.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dal
{
    public class TradeContext:DbContext
    {
        public TradeContext(DbContextOptions<TradeContext> db):base(db)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketDetail>()                 //Fluent api kullanılarak birleşik anahtar oluşturuldu.
                .HasKey(c => new { c.Id, c.ProductId });
        }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Counties> Counties { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Vat> Vats { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<BasketDetail> BasketDetails { get; set; }
        public DbSet<BasketMaster> BasketMasters { get; set; }
    }
}
