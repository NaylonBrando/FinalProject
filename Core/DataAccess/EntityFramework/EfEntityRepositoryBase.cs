using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //EntityFrameworkun diğer projelerdede kullanılması için evrensel repository
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>//Hangi tabloyu verirsek onun repositorisi olacak -->TEntitiy
        where TEntity:class, IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //Git, verikaynagindan gönderdigim productu bir tane nesneye ekle
                //Referansi yakala
                var addedEntity = context.Entry(entity);
                //veri kaynagini ilişkilendirdik şimdi ne yapacagizi söyledik
                addedEntity.State = EntityState.Added;
                //Ekle
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

       
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);//Dbsetlerinden producte bağlan
            }
        }
      
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //Dbsetteki Products için oraya yerleş
                //veritabanindaki tabloyu listeye çevir bana ver.
                //Arka planda select * from Products döndürüyor, onu bizim için bir listeye çeviriyor
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
