using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.UoW.Interface;
using BlogWebApp.ViewModel.Models;

namespace BlogWebApp.BLL.Services.Implementations
{
    public class TagService : ITagService
    {
        public TagService(IBlogWebAppUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        private IBlogWebAppUnitOfWork UnitOfWork { get; }

        public List<string> GetAllTagTitles()
        {
            var unmappedTags = UnitOfWork.Tags.GetAll().ToList();
            var mappedTags = Mapper.Map<List<Tag>, List<TagViewModel>>(unmappedTags);

            var tagsList = mappedTags.Select(tag => tag.Title).ToList();

            return tagsList;
        }

        public List<string> GetAllTagTitles(Expression<Func<ArticleAndTagViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleAndTagViewModel, bool>>, Expression<Func<ArticleAndTag, bool>>>(
                    predicate);

            var unmappedTags = UnitOfWork.ArticlesAndTags.GetAll(mappedPredicate);

            var tagTitlesList = new List<string>();

            foreach (var tag in unmappedTags)
            {
                var tagTitle = UnitOfWork.Tags.Get(t => t.Id == tag.TagId).Title;
                tagTitlesList.Add(tagTitle);
            }

            return tagTitlesList;
        }

        public void AddNewTags(List<TagViewModel> tags)
        {
            var mappedTags = Mapper.Map<List<TagViewModel>, List<Tag>>(tags);

            //add new tag to Tag table
            foreach (var item in mappedTags)
                if (!UnitOfWork.Tags.Exists(t => t.Title == item.Title))
                    UnitOfWork.Tags.Create(item);

            UnitOfWork.Save();
        }

        //add new record to ArticleAndTagTable
        public void AddTagsToArticle(Guid articleId, List<TagViewModel> tags)
        {
            if (!UnitOfWork.Articles.Exists(a => a.Id == articleId))
                throw new ObjectNotFoundException();

            var unmappedTags = Mapper.Map<List<TagViewModel>, List<Tag>>(tags);

            foreach (var tag in unmappedTags)
                if (UnitOfWork.Tags.Exists(t => t.Title == tag.Title))
                {
                    var foundedTag = UnitOfWork.Tags.Get(t => t.Title == tag.Title);

                    var articleAndTagEntity = new ArticleAndTag
                    {
                        ArticleId = articleId,
                        TagId = foundedTag.Id
                    };

                    UnitOfWork.ArticlesAndTags.Create(articleAndTagEntity);
                }
            UnitOfWork.Save();
        }

        public List<ArticleViewModel> GetArticlesByTag(string tag)
        {
            var tagId = UnitOfWork.Tags.Get(t => t.Title == tag).Id;

            var articlesWithTags = UnitOfWork.ArticlesAndTags.GetAll(a => a.TagId == tagId);

            var unmappedArticles = new List<Article>();

            foreach (var item in articlesWithTags)
            {
                var article = UnitOfWork.Articles.Get(a => a.Id == item.ArticleId);
                unmappedArticles.Add(article);
            }

            var mappedArticles = Mapper.Map<List<Article>, List<ArticleViewModel>>(unmappedArticles);

            return mappedArticles;
        }
    }
}