using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.Repository.Realizations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        protected BlogDb Db;

        public GenericRepository()
        {
            Db = new BlogDb();
        }

        public GenericRepository(BlogDb db)
        {
            Db = db;
        }

        public TEntity Get(Guid id)
        {
            return Db.Set<TEntity>().First(x => x.Id == id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().First(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Db.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Where(predicate);
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().First(predicate);
        }

        public bool Exists(Guid id)
        {
            return Db.Set<TEntity>().Any(x => x.Id == id);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Any(predicate);
        }

        public int Count()
        {
            return Db.Set<TEntity>().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Count(predicate);
        }

        public TEntity Create(TEntity entity)
        {
            var createdEntity = Db.Set<TEntity>().Add(entity);

            return createdEntity;
        }

        public TEntity Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;

            var updatedEntity = Get(entity.Id);

            return updatedEntity;
        }

        public void Delete(Guid id)
        {
            var entityForDelete = Db.Set<TEntity>().Find(id);

            if (entityForDelete == null)
                throw new NullReferenceException();

            Db.Set<TEntity>().Remove(entityForDelete);
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}