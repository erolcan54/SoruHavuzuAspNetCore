using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class SoruHavuzuDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-I5E4V7A\SQLEXPRESS;Database= SoruHavuzuDb; Trusted_Connection=true");
        }

        //public DbSet<Yazılımdaki Class> Veritabındaki tablo {get;set;}
        public DbSet<User> User { get; set; }
        public DbSet<il> il { get; set; }
        public DbSet<ilce> ilce { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<Brans> Brans { get; set; }
        public DbSet<Havuz> Havuz { get; set; }
        public DbSet<KurumTipi> KurumTipi { get; set; }
        public DbSet<KurumTuru> KurumTuru { get; set; }
        public DbSet<Secenek> Secenek { get; set; }
        public DbSet<Sinif> Sinif { get; set; }
        public DbSet<Soru> Soru { get; set; }
        public DbSet<SoruGosterim> SoruGosterim { get; set; }
        public DbSet<SoruMesaj> SoruMesaj { get; set; }
        public DbSet<SoruMesajCevap> SoruMesajCevap { get; set; }
        public DbSet<SoruPuan> SoruPuan { get; set; }
        public DbSet<SoruTuru> SoruTuru { get; set; }
        public DbSet<UserDetay> UserDetay { get; set; }
    }
}
