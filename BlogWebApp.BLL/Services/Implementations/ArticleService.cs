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
    public class ArticleService : IArticleService
    {
        public ArticleService(IBlogWebAppUnitOfWork unitOfWork, ITagService tagService)
        {
            UnitOfWork = unitOfWork;
            TagService = tagService;
        }

        private ITagService TagService { get; }
        private IBlogWebAppUnitOfWork UnitOfWork { get; }

        public ArticleViewModel Get(Guid id)
        {
            var unmappedArticle = UnitOfWork.Articles.Get(id);
            var mappedArticle = Mapper.Map<Article, ArticleViewModel>(unmappedArticle);

            return mappedArticle;
        }

        public ArticleViewModel Get(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);


            var unmappedArticle = UnitOfWork.Articles.Get(mappedPredicate);
            var mappedArticle = Mapper.Map<Article, ArticleViewModel>(unmappedArticle);

            return mappedArticle;
        }

        public List<ArticleViewModel> GetAll()
        {
            var unmappedList = UnitOfWork.Articles.GetAll();

            var mappedList = Mapper.Map<List<Article>, List<ArticleViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public List<ArticleViewModel> GetAll(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);

            var unmappedList = UnitOfWork.Articles.GetAll(mappedPredicate);

            var mappedList = Mapper.Map<List<Article>, List<ArticleViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public bool Exists(Guid id)
        {
            return UnitOfWork.Articles.Exists(id);
        }

        public bool Exists(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);

            return UnitOfWork.Articles.Exists(mappedPredicate);
        }

        public int Count()
        {
            return UnitOfWork.Articles.Count();
        }

        public int Count(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);

            return UnitOfWork.Articles.Count(mappedPredicate);
        }

        public ArticleViewModel Create(ArticleViewModel entity, List<TagViewModel> tagList)
        {
            var mappedEntityForCreate = Mapper.Map<ArticleViewModel, Article>(entity);

            if (UnitOfWork.Articles.Exists(e => e.Title == mappedEntityForCreate.Title))
                throw new DbEntityValidationException();

            //create new article
            var unmappedCreatedEntity = UnitOfWork.Articles.Create(mappedEntityForCreate);
            UnitOfWork.Save();

            //add record to Tag table, if list of tags contains something new
            TagService.AddNewTags(tagList);

            //binding tags to article
            TagService.AddTagsToArticle(unmappedCreatedEntity.Id, tagList);

            var mappedCreatedEntity = Mapper.Map<Article, ArticleViewModel>(unmappedCreatedEntity);

            return mappedCreatedEntity;
        }

        public ArticleViewModel Update(ArticleViewModel entity)
        {
            var mappedEntityForUpdate = Mapper.Map<ArticleViewModel, Article>(entity);

            var unmappedUpdatedEntity = UnitOfWork.Articles.Update(mappedEntityForUpdate);
            var mappedUpdatedEntity = Mapper.Map<Article, ArticleViewModel>(unmappedUpdatedEntity);

            return mappedUpdatedEntity;
        }

        public void Delete(Guid id)
        {
            UnitOfWork.Articles.Delete(id);
        }

        public void Save()
        {
            UnitOfWork.Save();
        }
    }
}