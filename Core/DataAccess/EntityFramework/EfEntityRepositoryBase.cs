using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TCortext>: IEntityRepository<TEntity>  
        where TEntity : class, IEntity, new()
        where TCortext: DbContext, new()
    {

        public void Add(TEntity entity)
        {
            //Blok dışına çıkınca Garbage Collector'e yönlendirilir
            //Bu örnek için, using bloğu bitince cortext hızlıca silinecek
            //IDısposable pattern implementation  of C#
            using (TCortext cortext = new TCortext())
            {
                var addedEntity = cortext.Entry(entity);
                addedEntity.State = EntityState.Added;
                cortext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TCortext cortext = new TCortext())
            {
                var deletedEntity = cortext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                cortext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TCortext cortext = new TCortext())
            {
                //Uygun koşula göre filtrelenmiş tek öğe döndürür
                return cortext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TCortext cortext = new TCortext())
            {

                return filter == null
                    //Filtre yok ise tüm listeyi getir
                    ? cortext.Set<TEntity>().ToList()
                    //Filtre var ise Where kullanarak sonucu getir
                    : cortext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TCortext cortext = new TCortext())
            {
                var updatedEntity = cortext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                cortext.SaveChanges();
            }
        }


    }
}
