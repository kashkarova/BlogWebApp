using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.UoW.Interface;
using BlogWebApp.ViewModel;

namespace BlogWebApp.BLL.Services.Implementations
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IBlogWebAppUnitOfWork _unitOfWork;

        public FeedbackService(IBlogWebAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public FeedbackViewModel Get(Guid id)
        {
            var unmappedFeedback = _unitOfWork.Feedbacks.Get(id);
            var mappedFeedback = Mapper.Map<Feedback, FeedbackViewModel>(unmappedFeedback);

            return mappedFeedback;
        }

        public FeedbackViewModel Get(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            var unmappedFeedback = _unitOfWork.Feedbacks.Get(mappedPredicate);
            var mappedFeedback = Mapper.Map<Feedback, FeedbackViewModel>(unmappedFeedback);

            return mappedFeedback;
        }

        public List<FeedbackViewModel> GetAll()
        {
            var unmappedList = _unitOfWork.Feedbacks.GetAll();

            var mappedList = Mapper.Map<List<Feedback>, List<FeedbackViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public List<FeedbackViewModel> GetAll(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            var unmappedList = _unitOfWork.Feedbacks.GetAll(mappedPredicate);

            var mappedList = Mapper.Map<List<Feedback>, List<FeedbackViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public bool Exists(Guid id)
        {
            return _unitOfWork.Feedbacks.Exists(id);
        }

        public bool Exists(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            return _unitOfWork.Feedbacks.Exists(mappedPredicate);
        }

        public int Count()
        {
            return _unitOfWork.Feedbacks.Count();
        }

        public int Count(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            return _unitOfWork.Feedbacks.Count(mappedPredicate);
        }

        public FeedbackViewModel Create(FeedbackViewModel entity)
        {
            var mappedEntityForCreate = Mapper.Map<FeedbackViewModel, Feedback>(entity);

            if (_unitOfWork.Feedbacks.Exists(e => e.Author == mappedEntityForCreate.Author))
                throw new DbEntityValidationException();

            var unmappedCreatedEntity = _unitOfWork.Feedbacks.Create(mappedEntityForCreate);
            var mappedCreatedEntity = Mapper.Map<Feedback, FeedbackViewModel>(unmappedCreatedEntity);

            return mappedCreatedEntity;
        }

        public FeedbackViewModel Update(FeedbackViewModel entity)
        {
            var mappedEntityForUpdate = Mapper.Map<FeedbackViewModel, Feedback>(entity);

            var unmappedUpdatedEntity = _unitOfWork.Feedbacks.Update(mappedEntityForUpdate);
            var mappedUpdatedEntity = Mapper.Map<Feedback, FeedbackViewModel>(unmappedUpdatedEntity);

            return mappedUpdatedEntity;
        }

        public void Delete(Guid id)
        {
            _unitOfWork.Feedbacks.Delete(id);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}