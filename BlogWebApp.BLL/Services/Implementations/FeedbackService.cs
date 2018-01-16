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
    public class FeedbackService : IFeedbackService
    {
        public FeedbackService(IBlogWebAppUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        private IBlogWebAppUnitOfWork UnitOfWork { get; }

        public FeedbackViewModel Get(Guid id)
        {
            var unmappedFeedback = UnitOfWork.Feedbacks.Get(id);
            var mappedFeedback = Mapper.Map<Feedback, FeedbackViewModel>(unmappedFeedback);

            return mappedFeedback;
        }

        public FeedbackViewModel Get(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            var unmappedFeedback = UnitOfWork.Feedbacks.Get(mappedPredicate);
            var mappedFeedback = Mapper.Map<Feedback, FeedbackViewModel>(unmappedFeedback);

            return mappedFeedback;
        }

        public List<FeedbackViewModel> GetAll()
        {
            var unmappedList = UnitOfWork.Feedbacks.GetAll();

            var mappedList = Mapper.Map<List<Feedback>, List<FeedbackViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public List<FeedbackViewModel> GetAll(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            var unmappedList = UnitOfWork.Feedbacks.GetAll(mappedPredicate);

            var mappedList = Mapper.Map<List<Feedback>, List<FeedbackViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public bool Exists(Guid id)
        {
            return UnitOfWork.Feedbacks.Exists(id);
        }

        public bool Exists(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            return UnitOfWork.Feedbacks.Exists(mappedPredicate);
        }

        public int Count()
        {
            return UnitOfWork.Feedbacks.Count();
        }

        public int Count(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            return UnitOfWork.Feedbacks.Count(mappedPredicate);
        }

        public FeedbackViewModel Create(FeedbackViewModel entity)
        {
            var mappedEntityForCreate = Mapper.Map<FeedbackViewModel, Feedback>(entity);

            if (UnitOfWork.Feedbacks.Exists(e => e.Author == mappedEntityForCreate.Author))
                throw new DbEntityValidationException();

            var unmappedCreatedEntity = UnitOfWork.Feedbacks.Create(mappedEntityForCreate);
            var mappedCreatedEntity = Mapper.Map<Feedback, FeedbackViewModel>(unmappedCreatedEntity);

            return mappedCreatedEntity;
        }

        public FeedbackViewModel Update(FeedbackViewModel entity)
        {
            var mappedEntityForUpdate = Mapper.Map<FeedbackViewModel, Feedback>(entity);

            var unmappedUpdatedEntity = UnitOfWork.Feedbacks.Update(mappedEntityForUpdate);
            var mappedUpdatedEntity = Mapper.Map<Feedback, FeedbackViewModel>(unmappedUpdatedEntity);

            return mappedUpdatedEntity;
        }

        public void Delete(Guid id)
        {
            UnitOfWork.Feedbacks.Delete(id);
        }

        public void Save()
        {
            UnitOfWork.Save();
        }
    }
}