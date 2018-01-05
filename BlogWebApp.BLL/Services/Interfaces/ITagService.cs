using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BlogWebApp.ViewModel;

namespace BlogWebApp.BLL.Services.Interfaces
{
    public interface ITagService
    {
        List<string> GetAllTagTitles();
        List<string> GetAllTagTitles(Expression<Func<ArticleAndTagViewModel, bool>> predicate);

        void AddNewTag(Guid articleId, List<string> tags);
        void AddTagsToArticle(Guid articleId, List<string> tags);
        List<ArticleViewModel> GetArticlesByTag(string tag);
    }
}