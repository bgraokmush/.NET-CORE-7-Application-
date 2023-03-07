using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : DB tabloları ile proje class'larını ilişkilendirme
    public class NorthWindCortext : DbContext
    {
        //Hangi altyapıyı kullandığımız metod
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //sql kullandığımızı tanımlıyoruz, nasıl bağlandığımız
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                Database=Northwind;
                Trusted_Connection=true;");
                /*
                   Server       -> Server  nerede olduğunu ifade ettik
                   Database     -> Bu sunucu içinde hangi veritabanını kullanacağımızı belirttil
                   Trusted_C... -> Kullanıcıadı ve şifre gerekmeden erişmeyi sağlar
                 */
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers{ get; set; }
    }
}
