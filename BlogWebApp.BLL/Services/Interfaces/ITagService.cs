using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BlogWebApp.ViewModel.Models;

namespace BlogWebApp.BLL.Services.Interfaces
{
    public interface ITagService
    {
        List<string> GetAllTagTitles();
        List<string> GetAllTagTitles(Expression<Func<ArticleAndTagViewModel, bool>> predicate);

        void AddNewTags(List<TagViewModel> tags);
        void AddTagsToArticle(Guid articleId, List<TagViewModel> tags);
        List<ArticleViewModel> GetArticlesByTag(string tag);
    }
}