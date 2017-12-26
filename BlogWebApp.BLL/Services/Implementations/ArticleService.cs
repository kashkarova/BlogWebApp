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
    public class ArticleService : IArticleService
    {
        private readonly ArticleRepository _articleRepository;
        private readonly BlogDb _db;


        public ArticleService()
        {
            _db = new BlogDb();
            _articleRepository = new ArticleRepository(_db);
        }

        public ArticleViewModel Get(Guid id)
        {
            var unmappedArticle = _articleRepository.Get(id);
            var mappedArticle = Mapper.Map<Article, ArticleViewModel>(unmappedArticle);

            return mappedArticle;
        }

        public ArticleViewModel Get(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);


            var unmappedArticle = _articleRepository.Get(mappedPredicate);
            var mappedArticle = Mapper.Map<Article, ArticleViewModel>(unmappedArticle);

            return mappedArticle;
        }

        public List<ArticleViewModel> GetAll()
        {
            var unmappedList = _articleRepository.GetAll();

            var mappedList = Mapper.Map<List<Article>, List<ArticleViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public List<ArticleViewModel> GetAll(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);

            var unmappedList = _articleRepository.GetAll(mappedPredicate);

            var mappedList = Mapper.Map<List<Article>, List<ArticleViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public ArticleViewModel First(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);

            var unmappedArticle = _articleRepository.First(mappedPredicate);
            var mappedArticle = Mapper.Map<Article, ArticleViewModel>(unmappedArticle);

            return mappedArticle;
        }

        public bool Exists(Guid id)
        {
            return _articleRepository.Exists(id);
        }

        public bool Exists(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);

            return _articleRepository.Exists(mappedPredicate);
        }

        public int Count()
        {
            return _articleRepository.Count();
        }

        public int Count(Expression<Func<ArticleViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleViewModel, bool>>, Expression<Func<Article, bool>>>(predicate);

            return _articleRepository.Count(mappedPredicate);
        }

        public ArticleViewModel Create(ArticleViewModel entity)
        {
            var mappedEntityForCreate = Mapper.Map<ArticleViewModel, Article>(entity);

            if (_articleRepository.Exists(e => e.Title == mappedEntityForCreate.Title))
                throw new DbEntityValidationException();

            var unmappedCreatedEntity = _articleRepository.Create(mappedEntityForCreate);
            var mappedCreatedEntity = Mapper.Map<Article, ArticleViewModel>(unmappedCreatedEntity);

            return mappedCreatedEntity;
        }

        public ArticleViewModel Update(ArticleViewModel entity)
        {
            var mappedEntityForUpdate = Mapper.Map<ArticleViewModel, Article>(entity);

            var unmappedUpdatedEntity = _articleRepository.Update(mappedEntityForUpdate);
            var mappedUpdatedEntity = Mapper.Map<Article, ArticleViewModel>(unmappedUpdatedEntity);

            return mappedUpdatedEntity;
        }

        public void Delete(Guid id)
        {
            _articleRepository.Delete(id);
        }

        public void Save()
        {
            _articleRepository.Save();
        }
    }
}