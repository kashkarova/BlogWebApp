using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.UoW.Interface;
using BlogWebApp.ViewModel;

namespace BlogWebApp.BLL.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IBlogWebAppUnitOfWork _unitOfWork;

        public AuthorService(IBlogWebAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AuthorViewModel Get(Guid id)
        {
            var unmapperAuthor = _unitOfWork.Authors.Get(id);
            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmapperAuthor);

            return mappedAuthor;
        }

        public AuthorViewModel Get(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            var unmapperAuthor = _unitOfWork.Authors.Get(mappedPredicate);
            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmapperAuthor);

            return mappedAuthor;
        }

        public List<AuthorViewModel> GetAll()
        {
            var unmappedList = _unitOfWork.Authors.GetAll();
            var mappedList = Mapper.Map<List<Author>, List<AuthorViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public List<AuthorViewModel> GetAll(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            var unmappedList = _unitOfWork.Authors.GetAll(mappedPredicate);
            var mappedList = Mapper.Map<List<Author>, List<AuthorViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public bool Exists(Guid id)
        {
            return _unitOfWork.Authors.Exists(id);
        }

        public bool Exists(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            return _unitOfWork.Authors.Exists(mappedPredicate);
        }

        public int Count()
        {
            return _unitOfWork.Authors.Count();
        }

        public int Count(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            return _unitOfWork.Authors.Count(mappedPredicate);
        }

        public AuthorViewModel Create(AuthorViewModel entity)
        {
            var mappedEntityForCreate = Mapper.Map<AuthorViewModel, Author>(entity);

            if (_unitOfWork.Authors.Exists(e => e.NickName == mappedEntityForCreate.NickName))
                throw new DbEntityValidationException();

            var unmappedCreatedEntity = _unitOfWork.Authors.Create(mappedEntityForCreate);
            var mappedCreatedEntity = Mapper.Map<Author, AuthorViewModel>(unmappedCreatedEntity);

            return mappedCreatedEntity;
        }

        public AuthorViewModel Update(AuthorViewModel entity)
        {
            var mappedEntityForUpdate = Mapper.Map<AuthorViewModel, Author>(entity);

            var unmappedUpdatedEntity = _unitOfWork.Authors.Update(mappedEntityForUpdate);
            var mappedUpdatedEntity = Mapper.Map<Author, AuthorViewModel>(unmappedUpdatedEntity);

            return mappedUpdatedEntity;
        }

        public void Delete(Guid id)
        {
            _unitOfWork.Authors.Delete(id);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}