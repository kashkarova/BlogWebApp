using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BlogWebApp.ViewModel.Models;

namespace BlogWebApp.BLL.Services.Interfaces
{
    public interface IFeedbackService
    {
        FeedbackViewModel Get(Guid id);
        FeedbackViewModel Get(Expression<Func<FeedbackViewModel, bool>> predicate);

        List<FeedbackViewModel> GetAll();
        List<FeedbackViewModel> GetAll(Expression<Func<FeedbackViewModel, bool>> predicate);

        bool Exists(Guid id);
        bool Exists(Expression<Func<FeedbackViewModel, bool>> predicate);

        int Count();
        int Count(Expression<Func<FeedbackViewModel, bool>> predicate);

        FeedbackViewModel Create(FeedbackViewModel entity);
        FeedbackViewModel Update(FeedbackViewModel entity);
        void Delete(Guid id);
        void Save();
    }
}