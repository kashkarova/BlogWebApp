using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.UoW.Interface;
using BlogWebApp.ViewModel.Models;

namespace BlogWebApp.BLL.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        public AuthorService(IBlogWebAppUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        private IBlogWebAppUnitOfWork UnitOfWork { get; }

        public AuthorViewModel Get(Guid id)
        {
            var unmapperAuthor = UnitOfWork.Authors.Get(id);
            var mappedAuthor = Mapper.Map<Questionare, AuthorViewModel>(unmapperAuthor);

            return mappedAuthor;
        }

        public AuthorViewModel Get(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Questionare, bool>>>(predicate);

            var unmapperAuthor = UnitOfWork.Authors.Get(mappedPredicate);
            var mappedAuthor = Mapper.Map<Questionare, AuthorViewModel>(unmapperAuthor);

            return mappedAuthor;
        }

        public List<AuthorViewModel> GetAll()
        {
            var unmappedList = UnitOfWork.Authors.GetAll();
            var mappedList = Mapper.Map<List<Questionare>, List<AuthorViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public List<AuthorViewModel> GetAll(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Questionare, bool>>>(predicate);

            var unmappedList = UnitOfWork.Authors.GetAll(mappedPredicate);
            var mappedList = Mapper.Map<List<Questionare>, List<AuthorViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public bool Exists(Guid id)
        {
            return UnitOfWork.Authors.Exists(id);
        }

        public bool Exists(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Questionare, bool>>>(predicate);

            return UnitOfWork.Authors.Exists(mappedPredicate);
        }

        public int Count()
        {
            return UnitOfWork.Authors.Count();
        }

        public int Count(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Questionare, bool>>>(predicate);

            return UnitOfWork.Authors.Count(mappedPredicate);
        }

        public AuthorViewModel Create(AuthorViewModel entity)
        {
            var mappedEntityForCreate = Mapper.Map<AuthorViewModel, Questionare>(entity);

            if (UnitOfWork.Authors.Exists(e => e.User.UserName == mappedEntityForCreate.User.UserName))
                throw new DbEntityValidationException();

            var unmappedCreatedEntity = UnitOfWork.Authors.Create(mappedEntityForCreate);
            var mappedCreatedEntity = Mapper.Map<Questionare, AuthorViewModel>(unmappedCreatedEntity);

            return mappedCreatedEntity;
        }

        public AuthorViewModel Update(AuthorViewModel entity)
        {
            var mappedEntityForUpdate = Mapper.Map<AuthorViewModel, Questionare>(entity);

            var unmappedUpdatedEntity = UnitOfWork.Authors.Update(mappedEntityForUpdate);
            var mappedUpdatedEntity = Mapper.Map<Questionare, AuthorViewModel>(unmappedUpdatedEntity);

            return mappedUpdatedEntity;
        }

        public void Delete(Guid id)
        {
            UnitOfWork.Authors.Delete(id);
        }

        public void Save()
        {
            UnitOfWork.Save();
        }
    }
}