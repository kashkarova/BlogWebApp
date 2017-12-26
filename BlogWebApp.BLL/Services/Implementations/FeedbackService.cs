using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Realizations;
using BlogWebApp.ViewModel;

namespace BlogWebApp.BLL.Services.Implementations
{
    public class FeedbackService : IFeedbackService
    {
        private readonly BlogDb _db;
        private readonly FeedbackRepository _feedbackRepository;

        public FeedbackService()
        {
            _db = new BlogDb();
            _feedbackRepository = new FeedbackRepository(_db);
        }

        public FeedbackService(FeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public FeedbackViewModel Get(Guid id)
        {
            var unmappedFeedback = _feedbackRepository.Get(id);
            var mappedFeedback = Mapper.Map<Feedback, FeedbackViewModel>(unmappedFeedback);

            return mappedFeedback;
        }

        public FeedbackViewModel Get(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            var unmappedFeedback = _feedbackRepository.Get(mappedPredicate);
            var mappedFeedback = Mapper.Map<Feedback, FeedbackViewModel>(unmappedFeedback);

            return mappedFeedback;
        }

        public List<FeedbackViewModel> GetAll()
        {
            var unmappedList = _feedbackRepository.GetAll();

            var mappedList = Mapper.Map<List<Feedback>, List<FeedbackViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public List<FeedbackViewModel> GetAll(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            var unmappedList = _feedbackRepository.GetAll(mappedPredicate);

            var mappedList = Mapper.Map<List<Feedback>, List<FeedbackViewModel>>(unmappedList.ToList());

            return mappedList;
        }

        public FeedbackViewModel First(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            var unmappedFeedback = _feedbackRepository.First(mappedPredicate);
            var mappedFeedback = Mapper.Map<Feedback, FeedbackViewModel>(unmappedFeedback);

            return mappedFeedback;
        }

        public bool Exists(Guid id)
        {
            return _feedbackRepository.Exists(id);
        }

        public bool Exists(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            return _feedbackRepository.Exists(mappedPredicate);
        }

        public int Count()
        {
            return _feedbackRepository.Count();
        }

        public int Count(Expression<Func<FeedbackViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<FeedbackViewModel, bool>>, Expression<Func<Feedback, bool>>>(predicate);

            return _feedbackRepository.Count(mappedPredicate);
        }

        public FeedbackViewModel Create(FeedbackViewModel entity)
        {
            var mappedEntityForCreate = Mapper.Map<FeedbackViewModel, Feedback>(entity);

            if (_feedbackRepository.Exists(e => e.Author == mappedEntityForCreate.Author))
                throw new DbEntityValidationException();

            var unmappedCreatedEntity = _feedbackRepository.Create(mappedEntityForCreate);
            var mappedCreatedEntity = Mapper.Map<Feedback, FeedbackViewModel>(unmappedCreatedEntity);

            return mappedCreatedEntity;
        }

        public FeedbackViewModel Update(FeedbackViewModel entity)
        {
            var mappedEntityForUpdate = Mapper.Map<FeedbackViewModel, Feedback>(entity);

            var unmappedUpdatedEntity = _feedbackRepository.Update(mappedEntityForUpdate);
            var mappedUpdatedEntity = Mapper.Map<Feedback, FeedbackViewModel>(unmappedUpdatedEntity);

            return mappedUpdatedEntity;
        }

        public void Delete(Guid id)
        {
            _feedbackRepository.Delete(id);
        }

        public void Save()
        {
            _feedbackRepository.Save();
        }
    }
}