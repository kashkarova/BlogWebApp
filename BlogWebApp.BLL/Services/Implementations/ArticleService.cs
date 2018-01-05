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
    public class ArticleService : IArticleService
    {
        private readonly ITagService _tagService;
        private readonly IBlogWebAppUnitOfWork _unitOfWork;

        public ArticleService(IBlogWebAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tagService = new TagService(_unitOfWork);
        }

        public ArticleViewModel Get(Guid id)
        {
            var unmappedArticle = _unitOfWork.Articles.Get(id);
            var mappedArticle = Mapper.Map<Article, ArticleViewModel>(unmappedArticle);

            return mappedArticle;
        }

        public ArticleViewModel Get(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);


            var unmappedArticle = _unitOfWork.Articles.Get(mappedPredicate);
            var mappedArticle = Mapper.Map<Article, ArticleViewModel>(unmappedArticle);

            return mappedArticle;
        }

        public List<ArticleViewModel> GetAll()
        {
            var unmappedList = _unitOfWork.Articles.GetAll();

            var mappedList = Mapper.Map<List<Article>, List<ArticleViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public List<ArticleViewModel> GetAll(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);

            var unmappedList = _unitOfWork.Articles.GetAll(mappedPredicate);

            var mappedList = Mapper.Map<List<Article>, List<ArticleViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public bool Exists(Guid id)
        {
            return _unitOfWork.Articles.Exists(id);
        }

        public bool Exists(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);

            return _unitOfWork.Articles.Exists(mappedPredicate);
        }

        public int Count()
        {
            return _unitOfWork.Articles.Count();
        }

        public int Count(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);

            return _unitOfWork.Articles.Count(mappedPredicate);
        }

        public ArticleViewModel Create(ArticleViewModel entity, string tags)
        {
            var mappedEntityForCreate = Mapper.Map<ArticleViewModel, Article>(entity);

            if (_unitOfWork.Articles.Exists(e => e.Title == mappedEntityForCreate.Title))
                throw new DbEntityValidationException();

            //create new article
            var unmappedCreatedEntity = _unitOfWork.Articles.Create(mappedEntityForCreate);
            _unitOfWork.Save();

            //split tags from string to list
            var tagList = tags.Split(' ').ToList();

            //add record to Tag table, if list of tags contains something new
            _tagService.AddNewTag(unmappedCreatedEntity.Id, tagList);

            //binding tags to article
            _tagService.AddTagsToArticle(unmappedCreatedEntity.Id, tagList);

            var mappedCreatedEntity = Mapper.Map<Article, ArticleViewModel>(unmappedCreatedEntity);

            return mappedCreatedEntity;
        }

        public ArticleViewModel Update(ArticleViewModel entity)
        {
            var mappedEntityForUpdate = Mapper.Map<ArticleViewModel, Article>(entity);

            var unmappedUpdatedEntity = _unitOfWork.Articles.Update(mappedEntityForUpdate);
            var mappedUpdatedEntity = Mapper.Map<Article, ArticleViewModel>(unmappedUpdatedEntity);

            return mappedUpdatedEntity;
        }

        public void Delete(Guid id)
        {
            _unitOfWork.Articles.Delete(id);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}