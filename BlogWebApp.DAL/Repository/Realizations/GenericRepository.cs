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
        private readonly BlogDb _db = new BlogDb();

        public TEntity Get(Guid id)
        {
            return _db.Set<TEntity>().First(x => x.Id == id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().First(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate);
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().First(predicate);
        }

        public bool Exists(Guid id)
        {
            return _db.Set<TEntity>().Any(x => x.Id == id);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Any(predicate);
        }

        public int Count()
        {
            return _db.Set<TEntity>().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Count(predicate);
        }

        public TEntity Create(TEntity entity)
        {
            var createdEntity = _db.Set<TEntity>().Add(entity);

            return createdEntity;
        }

        public TEntity Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;

            var updatedEntity = Get(entity.Id);

            return updatedEntity;
        }

        public void Delete(Guid id)
        {
            var entityForDelete = _db.Set<TEntity>().Find(id);

            if (entityForDelete == null)
                throw new NullReferenceException();

            _db.Set<TEntity>().Remove(entityForDelete);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}