using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Implementation;
using BlogWebApp.ViewModel;

namespace BlogWebApp.BLL.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly AuthorRepository _authorRepository;
        private readonly BlogDb _db;

        public AuthorService()
        {
            _db = new BlogDb();
            _authorRepository = new AuthorRepository(_db);
        }

        public AuthorViewModel Get(Guid id)
        {
            var unmapperAuthor = _authorRepository.Get(id);
            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmapperAuthor);

            return mappedAuthor;
        }

        public AuthorViewModel Get(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            var unmapperAuthor = _authorRepository.Get(mappedPredicate);
            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmapperAuthor);

            return mappedAuthor;
        }

        public List<AuthorViewModel> GetAll()
        {
            var unmappedList = _authorRepository.GetAll();
            var mappedList = Mapper.Map<List<Author>, List<AuthorViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public List<AuthorViewModel> GetAll(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            var unmappedList = _authorRepository.GetAll(mappedPredicate);
            var mappedList = Mapper.Map<List<Author>, List<AuthorViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public AuthorViewModel First(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            var unmappedAuthor = _authorRepository.First(mappedPredicate);
            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmappedAuthor);

            return mappedAuthor;
        }

        public bool Exists(Guid id)
        {
            return _authorRepository.Exists(id);
        }

        public bool Exists(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            return _authorRepository.Exists(mappedPredicate);
        }

        public int Count()
        {
            return _authorRepository.Count();
        }

        public int Count(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            return _authorRepository.Count(mappedPredicate);
        }

        public AuthorViewModel Create(AuthorViewModel entity)
        {
            var mappedEntityForCreate = Mapper.Map<AuthorViewModel, Author>(entity);

            if (_authorRepository.Exists(e => e.NickName == mappedEntityForCreate.NickName))
                throw new DbEntityValidationException();

            var unmappedCreatedEntity = _authorRepository.Create(mappedEntityForCreate);
            var mappedCreatedEntity = Mapper.Map<Author, AuthorViewModel>(unmappedCreatedEntity);

            return mappedCreatedEntity;
        }

        public AuthorViewModel Update(AuthorViewModel entity)
        {
            var mappedEntityForUpdate = Mapper.Map<AuthorViewModel, Author>(entity);

            var unmappedUpdatedEntity = _authorRepository.Update(mappedEntityForUpdate);
            var mappedUpdatedEntity = Mapper.Map<Author, AuthorViewModel>(unmappedUpdatedEntity);

            return mappedUpdatedEntity;
        }

        public void Delete(Guid id)
        {
            _authorRepository.Delete(id);
        }

        public void Save()
        {
            _authorRepository.Save();
        }
    }
}