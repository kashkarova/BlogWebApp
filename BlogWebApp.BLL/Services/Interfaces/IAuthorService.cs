using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BlogWebApp.ViewModel.Models;

namespace BlogWebApp.BLL.Services.Interfaces
{
    public interface IAuthorService
    {
        AuthorViewModel Get(Guid id);
        AuthorViewModel Get(Expression<Func<AuthorViewModel, bool>> predicate);

        List<AuthorViewModel> GetAll();
        List<AuthorViewModel> GetAll(Expression<Func<AuthorViewModel, bool>> predicate);

        bool Exists(Guid id);
        bool Exists(Expression<Func<AuthorViewModel, bool>> predicate);

        int Count();
        int Count(Expression<Func<AuthorViewModel, bool>> predicate);

        AuthorViewModel Create(AuthorViewModel entity);
        AuthorViewModel Update(AuthorViewModel entity);
        void Delete(Guid id);
        void Save();
    }
}