using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BlogWebApp.ViewModel;

namespace BlogWebApp.BLL.Services.Interfaces
{
    public interface IArticleService
    {
        ArticleViewModel Get(Guid id);
        ArticleViewModel Get(Expression<Func<ArticleViewModel, bool>> predicate);

        List<ArticleViewModel> GetAll();
        List<ArticleViewModel> GetAll(Expression<Func<ArticleViewModel, bool>> predicate);

        bool Exists(Guid id);
        bool Exists(Expression<Func<ArticleViewModel, bool>> predicate);

        int Count();
        int Count(Expression<Func<ArticleViewModel, bool>> predicate);

        ArticleViewModel Create(ArticleViewModel entity, string tags);
        ArticleViewModel Update(ArticleViewModel entity);
        void Delete(Guid id);
        void Save();
    }
}