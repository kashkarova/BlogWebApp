﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.Repository.Implementation
{
    public class GenericRepository<TEntity> :
        IGenericRepository<TEntity>
        where TEntity : class
    {
        public GenericRepository(BlogDb db)
        {
            Db = db;
        }

        private BlogDb Db { get; }

        public virtual TEntity Get(Guid id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().First(predicate);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Db.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Where(predicate);
        }

        public virtual bool Exists(Guid id)
        {
            var item = Db.Set<TEntity>().Find(id);

            return item != null;
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Any(predicate);
        }

        public virtual int Count()
        {
            return Db.Set<TEntity>().Count();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Count(predicate);
        }

        public virtual TEntity Create(TEntity entity)
        {
            var createdEntity = Db.Set<TEntity>().Add(entity);

            return createdEntity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public virtual void Delete(Guid id)
        {
            var entityForDelete = Db.Set<TEntity>().Find(id);

            if (entityForDelete == null)
                throw new NullReferenceException();

            Db.Set<TEntity>().Remove(entityForDelete);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}