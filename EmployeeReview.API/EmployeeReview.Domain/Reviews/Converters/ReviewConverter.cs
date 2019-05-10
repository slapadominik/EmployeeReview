﻿using System;
using AutoMapper;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Reviews.Converters.Interfaces;
using EmployeeReview.Domain.Reviews.DTO;
using EmployeeReview.Domain.UserManagement.DTO;

namespace EmployeeReview.Domain.Reviews.Converters
{
    public class ReviewConverter : IReviewConverter
    {
        private IMapper _mapper;
        private IReviewAuthorConverter _reviewAuthorConverter;

        public ReviewConverter(IReviewAuthorConverter reviewAuthorConverter)
        {
            _reviewAuthorConverter = reviewAuthorConverter;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReviewCommand, ReviewDAO>()
                    .ForMember(x => x.User, opt => opt.Ignore())
                    .ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<ReviewDAO, ReviewQuery>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        public ReviewDAO Convert(ReviewCommand reviewCommand, DateTime created, Guid authorId)
        {
            var review = _mapper.Map<ReviewDAO>(reviewCommand);
            review.Created = created;
            review.AuthorId = authorId;
            return review;
        }

        public ReviewQuery Convert(ReviewDAO reviewDao, UserDAO authorDao)
        {
            var review = _mapper.Map<ReviewQuery>(reviewDao);
            review.Author = _reviewAuthorConverter.Convert(authorDao);
            return review;
        }
    }
}