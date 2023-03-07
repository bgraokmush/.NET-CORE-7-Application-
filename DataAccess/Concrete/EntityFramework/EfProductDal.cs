using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {

        public void Add(Product entity)
        {
            //Blok dışına çıkınca Garbage Collector'e yönlendirilir
            //Bu örnek için, using bloğu bitince cortext hızlıca silinecek
            //IDısposable pattern implementation  of C#
            using (NorthWindCortext cortext = new NorthWindCortext())
            {
                var addedEntity = cortext.Entry(entity);
                addedEntity.State = EntityState.Added;
                cortext.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthWindCortext cortext = new NorthWindCortext())
            {
                var deletedEntity = cortext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                cortext.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthWindCortext cortext = new NorthWindCortext())
            {
                //Uygun koşula göre filtrelenmiş tek öğe döndürür
                return cortext.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthWindCortext cortext = new NorthWindCortext())
            {
                
                return filter == null 
                    //Filtre yok ise tüm listeyi getir
                    ? cortext.Set<Product>().ToList()
                    //Filtre var ise Where kullanarak sonucu getir
                    : cortext.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthWindCortext cortext = new NorthWindCortext())
            {
                var updatedEntity = cortext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                cortext.SaveChanges();
            }
        }
    }
}
