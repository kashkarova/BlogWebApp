using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.UoW.Interface;
using BlogWebApp.ViewModel;

namespace BlogWebApp.BLL.Services.Implementations
{
    public class TagService : ITagService
    {
        private readonly IBlogWebAppUnitOfWork _unitOfWork;

        public TagService(IBlogWebAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<string> GetAllTagTitles()
        {
            var unmappedTags = _unitOfWork.Tags.GetAll().ToList();
            var mappedTags = Mapper.Map<List<Tag>, List<TagViewModel>>(unmappedTags);

            return mappedTags.Select(tag => tag.Title).ToList();
        }

        public List<string> GetAllTagTitles(Expression<Func<ArticleAndTagViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleAndTagViewModel, bool>>, Expression<Func<ArticleAndTag, bool>>>(predicate);

            var unmappedTags = _unitOfWork.ArticlesAndTags.GetAll(mappedPredicate);

            var tagTitlesList = new List<string>();

            foreach (var tag in unmappedTags)
            {
                tagTitlesList.Add(_unitOfWork.Tags.Get(t=>t.Id==tag.TagId).Title);
            }

            return tagTitlesList;
        }

        public void AddNewTag(Guid articleId, List<string> tags)
        {
            //add new tag to Tag table
            foreach (var item in tags)
            {
                if (!_unitOfWork.Tags.Exists(t => t.Title == item))
                {
                    var tag = new Tag() { Title = item };

                    _unitOfWork.Tags.Create(tag);
                }
            }

            _unitOfWork.Save();
        }

        //add new record to ArticleAndTagTable
        public void AddTagsToArticle(Guid articleId, List<string> tags)
        {
            foreach (var tag in tags)
            {
                if (_unitOfWork.Tags.Exists(t => t.Title == tag))
                {
                    var foundedTag = _unitOfWork.Tags.Get(t => t.Title == tag);

                    var articleAndTagEntity = new ArticleAndTag()
                    {
                        ArticleId = articleId,
                        TagId = foundedTag.Id
                    };

                    _unitOfWork.ArticlesAndTags.Create(articleAndTagEntity);
                }
            }
            _unitOfWork.Save();
        }

        public List<ArticleViewModel> GetArticlesByTag(string tag)
        {
            var tagId = _unitOfWork.Tags.Get(t => t.Title == tag).Id;

            var articlesWithTags = _unitOfWork.ArticlesAndTags.GetAll(a => a.TagId == tagId);

            var unmappedArticles = new List<Article>();

            foreach (var item in articlesWithTags)
            {
                var article = _unitOfWork.Articles.Get(a => a.Id == item.ArticleId);
                unmappedArticles.Add(article);
            }

            var mappedArticles = Mapper.Map<List<Article>, List<ArticleViewModel>>(unmappedArticles);

            return mappedArticles;
        }
    }
}